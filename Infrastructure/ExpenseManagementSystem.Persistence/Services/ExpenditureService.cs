using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.UnitOfWork;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using ExpenseManagementSystem.Application.Exceptions;
using ExpenseManagementSystem.Application.Helpers;
using ExpenseManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseStatusRepository _expenseStatusRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public ExpenditureService(IUnitOfWork unitOfWork, IExpenditureRepository expenditureRepository,
            IMapper mapper, IExpenseRepository expenseRepository, ICategoryRepository categoryRepository, IExpenseStatusRepository expenseStatusRepository,
            IUserAccessor userAccessor)
        {
            _unitOfWork = unitOfWork;
            _expenditureRepository = expenditureRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
            _expenseStatusRepository = expenseStatusRepository;
        }


        public async Task<ExpenditureResponseDto> CreateAsync(ExpenditureRequestDto model)
        {
            await ValidateBeforeCreate(model);

            var expenditure = _mapper.Map<Expenditure>(model);
            expenditure.ReceiptFilePath = await FileHelper.SaveFileAsync(model.ReceiptFile);
            expenditure.IsActive = true;

            var pendingStatusId = await _expenseStatusRepository.GetStatusIdByNameAsync("Pending");

            if (pendingStatusId == 0)
                throw new NotFoundException("Pending durumu bulunamadı.");

            expenditure.StatusId = pendingStatusId;

            await _expenditureRepository.AddAsync(expenditure);
            await UpdateExpenseTotalAsync(expenditure.ExpenseId);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ExpenditureResponseDto>(expenditure);
        }


        public async Task<ExpenditureResponseDto> UpdateAsync(long id, ExpenditureRequestDto model)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Harcama kaydı bulunamadı.");

            await ValidateBeforeUpdate(id, model);

            if (model.ReceiptFile != null)
            {
                expenditure.ReceiptFilePath = await FileHelper.SaveFileAsync(model.ReceiptFile);
            }

            expenditure.Description = model.Description;
            expenditure.Date = model.Date;
            expenditure.CategoryId = model.CategoryId;
            expenditure.Amount = model.Amount;
            expenditure.TaxAmount = model.TaxAmount;
            expenditure.ReceiptNumber = model.ReceiptNumber;

            _expenditureRepository.Update(expenditure);

            await UpdateExpenseTotalAsync(model.ExpenseId);
            await _unitOfWork.SaveChangesAsync();
            

            return _mapper.Map<ExpenditureResponseDto>(expenditure);
        }

        public async Task<bool> SoftDeleteAsync(long id)
        {
            var entity = await _expenditureRepository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Harcama kaydı bulunamadı.");

            if (!entity.IsActive)
                throw new ConflictException("Bu harcama zaten silinmiş.");

            entity.IsActive = false;

            _expenditureRepository.Update(entity);
            await UpdateExpenseTotalAsync(entity.ExpenseId);
            await _unitOfWork.SaveChangesAsync();
            

            return true;
        }


        public async Task<ExpenditureResponseDto> ApproveExpenditureAsync(long id, string? note)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Harcama kaydı bulunamadı.");

            if (!expenditure.IsActive)
                throw new ConflictException("Pasif harcama onaylanamaz.");

            var approvedStatusId = await _expenseStatusRepository.GetStatusIdByNameAsync("Approved");
            if (approvedStatusId == null)
                throw new NotFoundException("Approved durumu bulunamadı.");

            expenditure.StatusId = approvedStatusId;
            expenditure.ApprovalNote = note;
            expenditure.ApprovalDate = DateTime.UtcNow;
            expenditure.ApprovedById = _userAccessor.GetUserId();
           

            _expenditureRepository.Update(expenditure);

            await UpdateExpenseStatusAsync(expenditure.ExpenseId);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ExpenditureResponseDto>(expenditure);
        }


        public async Task<ExpenditureResponseDto> RejectExpenditureAsync(long id, string? note)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Harcama kaydı bulunamadı.");

            if (!expenditure.IsActive)
                throw new ConflictException("Pasif harcama reddedilemez.");

            var rejectedStatusId = await _expenseStatusRepository.GetStatusIdByNameAsync("Rejected");

            if (rejectedStatusId == 0)
                throw new NotFoundException("Rejected durumu bulunamadı.");

            expenditure.StatusId = rejectedStatusId;
            expenditure.ApprovalNote = note;
            expenditure.ApprovalDate = DateTime.UtcNow;
            expenditure.ApprovedById = _userAccessor.GetUserId();

            _expenditureRepository.Update(expenditure);

            await UpdateExpenseStatusAsync(expenditure.ExpenseId);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ExpenditureResponseDto>(expenditure);
        }


        private async Task UpdateExpenseStatusAsync(long expenseId)
        {
            var expense = await _expenseRepository
                .GetByIdWithIncludesAsync(expenseId, include =>
                 include.Include(e => e.Expenditures)
                .ThenInclude(e => e.Status));

            if (expense == null)
                throw new NotFoundException("Expense bulunamadı.");

            var expenditures = expense.Expenditures.Where(e => e.IsActive).ToList();

            bool allApproved = expenditures.All(e => e.Status != null && e.Status.Name == "Approved");
            bool allRejected = expenditures.All(e => e.Status != null && e.Status.Name == "Rejected");

            var status = await _expenseStatusRepository.GetStatusIdByNameAsync(
                allApproved ? "Approved" :
                allRejected ? "Rejected" : "Pending");

            expense.StatusId = status;
            _expenseRepository.Update(expense);
        }


        private async Task UpdateExpenseTotalAsync(long expenseId)
        {
            var expenditures = await _expenditureRepository
                .Where(x => x.ExpenseId == expenseId && x.IsActive, tracking: false)
                .ToListAsync();

            var total = expenditures.Sum(x => x.Amount + x.TaxAmount);

            var expense = await _expenseRepository.GetByIdAsync(expenseId)
                ?? throw new NotFoundException("Harcama bulunamadı.");

            expense.Total = total;
            _expenseRepository.Update(expense);
        }


        private async Task ValidateBeforeCreate(ExpenditureRequestDto model)
        {
            if (await _expenditureRepository.AnyAsync(x => x.ReceiptNumber == model.ReceiptNumber && x.IsActive))
                throw new ConflictException("Bu fiş numarası daha önce kullanılmış.");

            if (!await _categoryRepository.AnyAsync(x => x.Id == model.CategoryId && x.IsActive))
                throw new ConflictException("Geçerli bir kategori seçiniz.");

            if (!await _expenseRepository.AnyAsync(x => x.Id == model.ExpenseId && x.IsActive))
                throw new ConflictException("Geçerli bir harcama başvurusu bulunamadı.");
        }

        private async Task ValidateBeforeUpdate(long id, ExpenditureRequestDto model)
        {
            if (await _expenditureRepository.AnyAsync(x => x.ReceiptNumber == model.ReceiptNumber && x.Id != id && x.IsActive))
                throw new ConflictException("Bu fiş numarası başka bir kayıtla eşleşiyor.");

            if (!await _categoryRepository.AnyAsync(x => x.Id == model.CategoryId && x.IsActive))
                throw new ConflictException("Geçerli bir kategori seçiniz.");

            if (!await _expenseRepository.AnyAsync(x => x.Id == model.ExpenseId && x.IsActive))
                throw new ConflictException("Geçerli bir harcama başvurusu bulunamadı.");
        }

    }
}
