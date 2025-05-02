using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expenditure;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenditures.Commands.UpdateExpenditure
{
    public class UpdateExpenditureCommandHandler : IRequestHandler<UpdateExpenditureCommand, ExpenditureResponseDto>
    {
        private readonly IExpenditureService _expenditureService;
        private readonly IMapper _mapper;

        public UpdateExpenditureCommandHandler(IExpenditureService expenditureService, IMapper mapper)
        {
            _expenditureService = expenditureService;
            _mapper = mapper;
        }

        public async Task<ExpenditureResponseDto> Handle(UpdateExpenditureCommand request, CancellationToken cancellationToken)
        {
            var result = await _expenditureService.UpdateAsync(request.Id, request.Model);
            return _mapper.Map<ExpenditureResponseDto>(result);
        }
    }
}
