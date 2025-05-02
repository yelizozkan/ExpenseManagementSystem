using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expense;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class ExpenseQueryService : IExpenseQueryService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMapper _mapper;

        public ExpenseQueryService(IExpenseRepository expenseRepository, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _mapper = mapper;
        }

        public async Task<List<ExpenseResponseDto>> GetAllAsync()
        {
            var expenses = await _expenseRepository
                .Where(x => x.IsActive, tracking: false)
                .ToListAsync();

            return _mapper.Map<List<ExpenseResponseDto>>(expenses);
        }

        public async Task<ExpenseResponseDto?> GetByIdAsync(long id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            if (expense == null || !expense.IsActive)
                return null;

            return _mapper.Map<ExpenseResponseDto>(expense);
        }
    }
}
