using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using Microsoft.EntityFrameworkCore;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class ExpenseStatusQueryService : IExpenseStatusQueryService
    {
        private readonly IExpenseStatusRepository _expenseStatusRepository;
        private readonly IMapper _mapper;

        public ExpenseStatusQueryService(IExpenseStatusRepository expenseStatusRepository, IMapper mapper)
        {
            _expenseStatusRepository = expenseStatusRepository;
            _mapper = mapper;
        }

        public async Task<List<ExpenseStatusResponseDto>> GetAllAsync()
        {
            var statuses = await _expenseStatusRepository
                .Where(x => x.IsActive, tracking: false)
                .ToListAsync();

            return _mapper.Map<List<ExpenseStatusResponseDto>>(statuses);
        }

        public async Task<ExpenseStatusResponseDto?> GetByIdAsync(long id)
        {
            var status = await _expenseStatusRepository.GetByIdAsync(id);
            if (status == null || !status.IsActive)
                return null;

            return _mapper.Map<ExpenseStatusResponseDto>(status);
        }
    }
}
