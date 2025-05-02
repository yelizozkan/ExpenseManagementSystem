using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.CreateExpenditure
{
    public class CreateExpenditureCommandHandler : IRequestHandler<CreateExpenditureCommand, ExpenditureResponseDto>
    {
        private readonly IExpenditureService _expenditureService;
        private readonly IMapper _mapper;

        public CreateExpenditureCommandHandler(IExpenditureService expenditureService, IMapper mapper)
        {
            _expenditureService = expenditureService;
            _mapper = mapper;
        }

        public async Task<ExpenditureResponseDto> Handle(CreateExpenditureCommand request, CancellationToken cancellationToken)
        {
            var expenditure = new ExpenditureRequestDto
            {
                Amount = request.Model.Amount,
                Description = request.Model.Description,
                Date = request.Model.Date,
                CategoryId = request.Model.CategoryId,
                ExpenseId = request.Model.ExpenseId,
                TaxAmount = request.Model.TaxAmount,
                ReceiptFile = request.Model.ReceiptFile,
                ReceiptNumber = request.Model.ReceiptNumber
            };

            var result = await _expenditureService.CreateAsync(expenditure);
            return _mapper.Map<ExpenditureResponseDto>(expenditure);
        }
    }
}
