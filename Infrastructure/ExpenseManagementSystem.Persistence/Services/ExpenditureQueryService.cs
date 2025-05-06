using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Persistence.Services
{
    public class ExpenditureQueryService : IExpenditureQueryService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public ExpenditureQueryService(IExpenditureRepository expenditureRepository, IMapper mapper, IExpenseRepository expenseRepository, IUserAccessor userAccessor)
        {
            _expenditureRepository = expenditureRepository;
            _mapper = mapper;
            _expenseRepository = expenseRepository;
            _userAccessor = userAccessor;
        }

        public async Task<List<ExpenditureResponseDto>> GetAllAsync()
        {
            var role = _userAccessor.GetUserRole();
            var userId = _userAccessor.GetUserId();

            var query = _expenditureRepository.Where(x => x.IsActive, tracking: false);

            if (role == "Personnel")
            {
                query = query.Where(x => x.Expense.UserId == userId);
            }

            var expenditures = await query.ToListAsync();
            return _mapper.Map<List<ExpenditureResponseDto>>(expenditures);
        }

        public async Task<ExpenditureResponseDto?> GetByIdAsync(long id)
        {
            
            var expenditure = await _expenditureRepository.GetByIdAsync(id);

            if (expenditure == null || !expenditure.IsActive)
                return null;

            var role = _userAccessor.GetUserRole();
            var userId = _userAccessor.GetUserId();

            if (role == "Personnel")
            {
                var expense = await _expenseRepository.GetByIdAsync(expenditure.ExpenseId);
                if (expense == null || expense.UserId != userId)
                    return null;
            }

            return _mapper.Map<ExpenditureResponseDto>(expenditure);
        }
    }
}
