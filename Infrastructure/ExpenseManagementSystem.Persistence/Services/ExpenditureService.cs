using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.UnitOfWork;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using ExpenseManagementSystem.Application.Exceptions;
using ExpenseManagementSystem.Application.Helpers;
using ExpenseManagementSystem.Application.Responses;
using ExpenseManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ExpenditureService(IUnitOfWork unitOfWork, IExpenditureRepository expenditureRepository,
            IMapper mapper, IExpenseRepository expenseRepository, ICategoryRepository categoryRepository)
        {
            _unitOfWork = unitOfWork;
            _expenditureRepository = expenditureRepository;
            _mapper = mapper;
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<ExpenditureResponseDto> CreateAsync(ExpenditureRequestDto model)
        {
            await ValidateBeforeCreate(model);

            var expenditure = _mapper.Map<Expenditure>(model);
            expenditure.ReceiptFilePath = await FileHelper.SaveFileAsync(model.ReceiptFile);
            expenditure.IsActive = true;

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

            _mapper.Map(model, expenditure);

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


        public async Task<ApiResponse> ApproveForPaymentAsync(long id)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id)
        ?? throw new NotFoundException("Harcama kalemi bulunamadı.");

            if (expenditure.IsApprovedForPayment == true)
                throw new ConflictException("Bu kalem zaten ödeme için onaylanmış.");

            expenditure.IsApprovedForPayment = true;

            _expenditureRepository.Update(expenditure);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResponse("Ödeme için onaylandı", true);
        }

        public async Task<ApiResponse> RejectForPaymentAsync(long id)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Harcama kalemi bulunamadı.");

            if (expenditure.IsApprovedForPayment == false)
                throw new ConflictException("Bu kalem zaten ödeme için reddedilmiş.");

            expenditure.IsApprovedForPayment = false;

            _expenditureRepository.Update(expenditure);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResponse("Ödeme için reddedildi.", true);
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
