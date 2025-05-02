using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Persistence.Services
{
    public class ExpenditureQueryService : IExpenditureQueryService
    {
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IMapper _mapper;

        public ExpenditureQueryService(IExpenditureRepository expenditureRepository, IMapper mapper)
        {
            _expenditureRepository = expenditureRepository;
            _mapper = mapper;
        }

        public async Task<List<ExpenditureResponseDto>> GetAllAsync()
        {
            var expenditures = await _expenditureRepository
                .Where(x => x.IsActive, tracking: false)
                .ToListAsync();

            return _mapper.Map<List<ExpenditureResponseDto>>(expenditures);
        }

        public async Task<ExpenditureResponseDto?> GetByIdAsync(long id)
        {
            var expenditure = await _expenditureRepository.GetByIdAsync(id);
            if (expenditure == null || !expenditure.IsActive)
                return null;

            return _mapper.Map<ExpenditureResponseDto>(expenditure);
        }

        public async Task<List<ExpenditureResponseDto>> GetByParameterAsync(long? expenseId, long? categoryId, DateTime? date)
        {
            var query = _expenditureRepository.Where(x => x.IsActive, tracking: false);

            if (expenseId.HasValue)
                query = query.Where(x => x.ExpenseId == expenseId.Value);

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);

            if (date.HasValue)
                query = query.Where(x => x.Date.Date == date.Value.Date);

            var result = await query.ToListAsync();
            return _mapper.Map<List<ExpenditureResponseDto>>(result);
        }
    }
}
