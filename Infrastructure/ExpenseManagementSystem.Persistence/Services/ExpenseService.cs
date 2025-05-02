using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.UnitOfWork;
using ExpenseManagementSystem.Application.Dtos.Expense;
using ExpenseManagementSystem.Application.Exceptions;
using ExpenseManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace ExpenseManagementSystem.Persistence.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseStatusRepository _expenseStatusRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ExpenseService(
            IExpenseRepository expenseRepository,
            IExpenseStatusRepository expenseStatusRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _expenseRepository = expenseRepository;
            _expenseStatusRepository = expenseStatusRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Expense> CreateAsync(ExpenseRequestDto model)
        {
            var userId = GetCurrentUserId();
            var status = await GetPendingStatusAsync();

            var expense = _mapper.Map<Expense>(model);

            expense.UserId = userId;
            expense.SubmissionDate = DateTime.UtcNow;
            expense.StatusId = status.Id;

            await _expenseRepository.AddAsync(expense);
            await _unitOfWork.SaveChangesAsync();

            return expense;
        }


        public async Task<Expense> UpdateAsync(long id, ExpenseRequestDto model)
        {
            var userId = GetCurrentUserId();

            var entity = await _expenseRepository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException("Güncellenecek harcama bulunamadı.");

            if (entity.UserId != userId)
                throw new UnauthorizedAccessException("Yalnızca kendi masraflarınızı güncelleyebilirsiniz.");

            _mapper.Map(model, entity);
            _expenseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity;
        }


        public async Task<bool> DeleteAsync(long id)
        {
            var userId = GetCurrentUserId();

            var entity = await _expenseRepository.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException("Silinecek harcama bulunamadı.");

            if (entity.UserId != userId)
                throw new UnauthorizedAccessException("Yalnızca kendi masraflarınızı silebilirsiniz.");


            entity.IsActive = false;
            _expenseRepository.Update(entity);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }


        private long GetCurrentUserId()
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return long.Parse(userId ?? throw new UnauthorizedAccessException("Kullanıcı bilgisi alınamadı."));
        }


        private async Task<ExpenseStatus> GetPendingStatusAsync()
        {
            var status = await _expenseStatusRepository.GetByNameAsync("Pending");
            if (status == null)
                throw new NotFoundException("Varsayılan durum bulunamadı.");
            return status;
        }

    }
}
