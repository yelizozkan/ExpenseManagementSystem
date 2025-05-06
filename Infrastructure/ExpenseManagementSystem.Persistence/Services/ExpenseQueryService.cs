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
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public ExpenseQueryService(IExpenseRepository expenseRepository,IUserAccessor userAccessor,IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        public async Task<List<ExpenseResponseDto>> GetAllAsync()
        {
            var userId = _userAccessor.GetUserId();
            var role = _userAccessor.GetUserRole();


            var query = _expenseRepository
                .Table
                .Include(x => x.User)
                .Include(x => x.Expenditures)
                .Include(x => x.Status)
                .Where(x => x.IsActive);


            if (role != "Admin")
            {
                query = query.Where(x => x.UserId == userId);
            }

            var expenses = await query.ToListAsync();
            return _mapper.Map<List<ExpenseResponseDto>>(expenses);
        }
        

        public async Task<ExpenseResponseDto?> GetByIdAsync(long id)
        {
            var expense = await _expenseRepository
                .Table
                .Include(x => x.Expenditures)
                .Include(x => x.Status)
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (expense == null || !expense.IsActive)
                return null;

            var userId = _userAccessor.GetUserId();
            var role = _userAccessor.GetUserRole();

            if (role != "Admin" && expense.UserId != userId)
                return null;

            return _mapper.Map<ExpenseResponseDto>(expense);
        }
    }
}
