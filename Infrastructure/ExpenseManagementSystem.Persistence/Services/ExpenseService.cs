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

            var pendingStatusId = await GetStatusIdAsync("Pending");

            var expense = _mapper.Map<Expense>(model);

            expense.UserId = userId;
            expense.SubmissionDate = DateTime.UtcNow;
            expense.StatusId = pendingStatusId;
            expense.Total = 0;

            await _expenseRepository.AddAsync(expense);
            await _unitOfWork.SaveChangesAsync();

            var createdExpense = await _expenseRepository.GetByIdWithIncludesAsync(expense.Id,
                q => q.Include(e => e.User)
                .Include(e => e.Status)
                .Include(e => e.Expenditures));

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

            expense.Description = model.Description;
            expense.CategoryId = model.CategoryId;

            expense.Total = await CalculateTotalAsync(id);

            _expenseRepository.Update(expense);
            await _unitOfWork.SaveChangesAsync();

            var updatedExpense = await _expenseRepository.GetByIdWithIncludesAsync(expense.Id,
                    q => q.Include(e => e.User)
                    .Include(e => e.Status)
                    .Include(e => e.Expenditures));

            return _mapper.Map<ExpenseResponseDto>(updatedExpense);
        }


        public async Task<bool> SoftDeleteAsync(long id)
        {
            var userId = _userAccessor.GetUserId();

            var expense = await _expenseRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Silinecek masraf bulunamadı.");

            if (expense.UserId != userId)
                throw new UnauthorizedAccessException("Yalnızca kendi masraflarınızı silebilirsiniz.");

            var expenditures = await _expenditureRepository
                .Where(x => x.ExpenseId == expense.Id && x.IsActive)
                .ToListAsync();

            foreach (var item in expenditures)
            {
                item.IsActive = false;
                _expenditureRepository.Update(item);
            }


            expense.IsActive = false;
            _expenseRepository.Update(expense);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        private async Task EnsureValidCategory(long categoryId)
        {
            var isValid = await _categoryRepository.AnyAsync(x => x.Id == categoryId && x.IsActive);
            if (!isValid)
                throw new ConflictException("Geçerli bir kategori seçiniz.");
        }

        private async Task<long> GetStatusIdAsync(string statusName)
        {
            var statusId = await _expenseStatusRepository.GetStatusIdByNameAsync(statusName);

            if (statusId == 0)
                throw new NotFoundException($"'{statusName}' durumu bulunamadı.");

            return statusId;
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
