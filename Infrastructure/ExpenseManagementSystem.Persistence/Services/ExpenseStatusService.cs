using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.UnitOfWork;
using ExpenseManagementSystem.Application.Dtos.ExpenseStatus;
using ExpenseManagementSystem.Application.Exceptions;
using ExpenseManagementSystem.Domain.Entities;



namespace ExpenseManagementSystem.Persistence.Services
{
    public class ExpenseStatusService : IExpenseStatusService
    {
        private readonly IExpenseStatusRepository _expenseStatusRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExpenseStatusService(IExpenseStatusRepository expenseStatusRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _expenseStatusRepository = expenseStatusRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ExpenseStatusResponseDto> CreateAsync(ExpenseStatusRequestDto dto)
        {
            if (await _expenseStatusRepository.AnyAsync(x => x.Name == dto.Name && x.IsActive))
                throw new ConflictException("Bu durum adı zaten mevcut.");

            var entity = _mapper.Map<ExpenseStatus>(dto);
            entity.IsActive = true;

            await _expenseStatusRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ExpenseStatusResponseDto>(entity);
        }

        public async Task<ExpenseStatusResponseDto> UpdateAsync(long id, ExpenseStatusRequestDto dto)
        {
            var entity = await _expenseStatusRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Güncellenecek durum bulunamadı.");

            _mapper.Map(dto, entity);

            _expenseStatusRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ExpenseStatusResponseDto>(entity);
        }

        public async Task<bool> SoftDeleteAsync(long id)
        {
            var entity = await _expenseStatusRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Silinecek durum bulunamadı.");

            entity.IsActive = false;
            _expenseStatusRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
