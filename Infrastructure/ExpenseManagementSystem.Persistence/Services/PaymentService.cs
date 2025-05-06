using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Repository;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Abstractions.UnitOfWork;
using ExpenseManagementSystem.Application.Dtos.Payment;
using ExpenseManagementSystem.Application.Exceptions;
using ExpenseManagementSystem.Domain.Entities;

namespace ExpenseManagementSystem.Persistence.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IExpenditureRepository _expenditureRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentService(
            IPaymentRepository paymentRepository,
            IExpenditureRepository expenditureRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _expenditureRepository = expenditureRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<PaymentResponseDto> CreateAsync(PaymentRequestDto model)
        {
            var expenditure = await _expenditureRepository.GetByIdWithExpenseAndUserAsync(model.ExpenditureId)
                ?? throw new NotFoundException("Harcama bulunamadı.");

            ValidateExpenditureForPayment(expenditure);

            if (!expenditure.IsActive)
                throw new BusinessException("Pasif bir harcama için ödeme yapılamaz.");

            if (expenditure.Amount <= 0)
                throw new BusinessException("Geçersiz ödeme tutarı. Tutar sıfırdan büyük olmalıdır.");

            var hasExistingPayment = await _paymentRepository.AnyAsync(p => p.ExpenditureId == model.ExpenditureId);
            if (hasExistingPayment)
                throw new ConflictException("Bu harcama kalemi için zaten ödeme yapılmış.");

            var payment = new Payment
            {
                ExpenditureId = model.ExpenditureId,
                Amount = expenditure.Amount,
                TargetIban = expenditure.Expense.User!.Iban!,
                PaymentDate = DateTime.UtcNow
            };

            await _paymentRepository.AddAsync(payment);

            expenditure.Payment = payment;
            _expenditureRepository.Update(expenditure);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PaymentResponseDto>(payment);
        }


        public async Task<PaymentResponseDto> UpdateAsync(long id, PaymentRequestDto model)
        {
            var payment = await _paymentRepository.GetByIdAsync(id)
            ?? throw new NotFoundException("Ödeme kaydı bulunamadı.");

            var expenditure = await _expenditureRepository.GetByIdWithExpenseAndUserAsync(model.ExpenditureId)
                ?? throw new NotFoundException("Yeni harcama bulunamadı.");

            if (!expenditure.IsActive)
                throw new BusinessException("Pasif bir harcama için ödeme yapılamaz.");


            payment.ExpenditureId = model.ExpenditureId;
            payment.Amount = expenditure.Amount;
            payment.TargetIban = expenditure.Expense.User?.Iban ?? "";
            payment.PaymentDate = DateTime.UtcNow;

            _paymentRepository.Update(payment);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<PaymentResponseDto>(payment);
        }


        public async Task<bool> DeleteAsync(long id)
        {
            var payment = await _paymentRepository.GetByIdAsync(id)
                ?? throw new NotFoundException("Silinecek ödeme bulunamadı.");

            payment.IsActive = false;
            _paymentRepository.Update(payment);

            await _unitOfWork.SaveChangesAsync();
            return true;
        }


        private static void ValidateExpenditureForPayment(Expenditure expenditure)
        {
            if (expenditure.Payment != null)
                throw new ConflictException("Bu harcama için zaten ödeme yapılmış.");

            if (expenditure.Expense.Status?.Name != "Approved")
                throw new BusinessException("Harcama henüz onaylanmadığı için ödeme yapılamaz.");

            if (expenditure.IsApprovedForPayment != true)
                throw new BusinessException("Bu harcama kalemi için ödeme onayı verilmemiştir.");

            if (string.IsNullOrWhiteSpace(expenditure.Expense.User?.Iban))
                throw new BusinessException("Kullanıcının IBAN bilgisi eksik. Ödeme yapılamaz.");
        }

    }
}
