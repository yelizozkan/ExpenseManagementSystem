using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, ExpenseResponseDto>
    {
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;

        public CreateExpenseCommandHandler(IExpenseService expenseService, IMapper mapper)
        {
            _expenseService = expenseService;
            _mapper = mapper;
        }

        public async Task<ExpenseResponseDto> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            var result = await _expenseService.CreateAsync(request.Model);
            return _mapper.Map<ExpenseResponseDto>(result);
        }
    }
}
