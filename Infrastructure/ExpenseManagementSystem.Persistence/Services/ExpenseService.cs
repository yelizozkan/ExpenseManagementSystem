using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.UnitOfWork;
using ExpenseManagementSystem.Application.Dtos.Expense;
using ExpenseManagementSystem.Application.Exceptions;
using ExpenseManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IExpenseStatusRepository _expenseStatusRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public ExpenseService(
            IExpenseRepository expenseRepository,
            IExpenditureRepository expenditureRepository,
            IExpenseStatusRepository expenseStatusRepository,
            ICategoryRepository categoryRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IUserAccessor userAccessor)
        {
            _expenseRepository = expenseRepository;
            _expenditureRepository = expenditureRepository;
            _expenseStatusRepository = expenseStatusRepository;
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<ExpenseResponseDto> CreateAsync(ExpenseRequestDto model)
        {
            var userId = _userAccessor.GetUserId();

            await EnsureValidCategory(model.CategoryId);
            var status = await GetStatusIdAsync("Pending");

            var expense = _mapper.Map<Expense>(model);

            expense.UserId = userId;
            expense.SubmissionDate = DateTime.UtcNow;
            expense.StatusId = status;
            expense.Total = 0;

            await _expenseRepository.AddAsync(expense);
            await _unitOfWork.SaveChangesAsync();

            var createdExpense = await _expenseRepository
                .Table
                .Include(e => e.User)
                .Include(e => e.Status) 
                .Include(e => e.Expenditures) 
                .FirstOrDefaultAsync(e => e.Id == expense.Id);

            return _mapper.Map<ExpenseResponseDto>(createdExpense);
        }


        public async Task<ExpenseResponseDto> UpdateAsync(long id, ExpenseRequestDto model)
        {
            var userId = _userAccessor.GetUserId();
            await EnsureValidCategory(model.CategoryId);

            var expense = await _expenseRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Güncellenecek harcama bulunamadı.");

            if (expense.UserId != userId)
                throw new UnauthorizedAccessException("Yalnızca kendi masraflarınızı güncelleyebilirsiniz.");

            _mapper.Map(model, expense);

            expense.Total = await CalculateTotalAsync(id);

            _expenseRepository.Update(expense);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ExpenseResponseDto>(expense); 
        }


        public async Task<bool> SoftDeleteAsync(long id)
        {
            var userId = _userAccessor.GetUserId();

            var expense = await _expenseRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Silinecek masraf bulunamadı.");

            if (expense.UserId != userId)
                throw new UnauthorizedAccessException("Yalnızca kendi masraflarınızı silebilirsiniz.");

            expense.IsActive = false;
            _expenseRepository.Update(expense);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<ExpenseResponseDto> ApproveAsync(long expenseId, string? note)
        {
            var expense = await _expenseRepository.GetByIdAsync(expenseId)
                ?? throw new NotFoundException("Onaylanacak masraf bulunamadı.");

            var approvedStatus = await GetStatusIdAsync("Approved");

            if (expense.StatusId == approvedStatus)
                throw new ConflictException("Masraf zaten onaylanmış.");

            expense.StatusId = approvedStatus;
            expense.ApprovalDate = DateTime.UtcNow;
            expense.ApprovalNote = note;
            expense.ApprovedById = _userAccessor.GetUserId();

            _expenseRepository.Update(expense);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ExpenseResponseDto>(expense);
        }

        public async Task<ExpenseResponseDto> RejectAsync(long expenseId, string? rejectionNote)
        {
            var expense = await _expenseRepository.GetByIdAsync(expenseId)
                ?? throw new NotFoundException("Expense bulunamadı");

            var rejectedStatus = await _expenseStatusRepository.GetByNameAsync("Rejected")
                ?? throw new NotFoundException("Rejected durumu sistemde tanımlı değil");

            expense.StatusId = rejectedStatus.Id;
            expense.ApprovalNote = rejectionNote;
            expense.ApprovalDate = DateTime.UtcNow;
            expense.ApprovedById = _userAccessor.GetUserId();

            _expenseRepository.Update(expense);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ExpenseResponseDto>(expense);
        }


        private async Task EnsureValidCategory(long categoryId)
        {
            var isValid = await _categoryRepository.AnyAsync(x => x.Id == categoryId && x.IsActive);
            if (!isValid)
                throw new ConflictException("Geçerli bir kategori seçiniz.");
        }

        private async Task<long> GetStatusIdAsync(string statusName)
        {
            var status = await _expenseStatusRepository.GetByNameAsync(statusName);
            return status?.Id ?? throw new NotFoundException($"'{statusName}' durumu bulunamadı.");
        }

        private async Task<decimal> CalculateTotalAsync(long expenseId)
        {
            var expenditures = await _expenditureRepository
                .Where(x => x.ExpenseId == expenseId && x.IsActive, tracking: false)
                .ToListAsync();

            return expenditures.Sum(x => x.Amount + x.TaxAmount);
        }

    }
}
