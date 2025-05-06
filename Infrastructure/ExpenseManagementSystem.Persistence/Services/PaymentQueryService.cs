using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Payment;
using ExpenseManagementSystem.Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagementSystem.Persistence.Services
{
    public class PaymentQueryService : IPaymentQueryService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public PaymentQueryService(IPaymentRepository paymentRepository,IMapper mapper, IUserAccessor userAccessor)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }


        public async Task<List<PaymentResponseDto>> GetAllAsync()
        {
            var userId = _userAccessor.GetUserId();
            var role = _userAccessor.GetUserRole();

            var query = _paymentRepository
                .Table
                .Include(p => p.Expenditure)
                .ThenInclude(e => e.Expense)
                .Where(x => x.IsActive);


            if (role != "Admin")
            {
                query = query.Where(x => x.Expenditure.Expense.UserId == userId);
            }

            var payments = await query.ToListAsync();

            return _mapper.Map<List<PaymentResponseDto>>(payments);
        }

        public async Task<PaymentResponseDto> GetByIdAsync(long id)
        {
            var userId = _userAccessor.GetUserId();
            var role = _userAccessor.GetUserRole();

            var payment = await _paymentRepository
                .Table
                .Include(p => p.Expenditure)
                .ThenInclude(e => e.Expense)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);


            if (payment == null || (role != "Admin" && payment.Expenditure.Expense.UserId != userId))
                throw new NotFoundException("Ödeme bulunamadı.");

            return _mapper.Map<PaymentResponseDto>(payment);
        }

    }
}
