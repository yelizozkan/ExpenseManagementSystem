using AutoMapper;
using ExpenseManagementSystem.Application.Abstractions.Services;
using ExpenseManagementSystem.Application.Dtos.Expense;
using MediatR;


namespace ExpenseManagementSystem.Application.Features.Expenses.Commands.UpdateExpense
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, ExpenseResponseDto>
    {
        private readonly IExpenseService _expenseService;
        private readonly IMapper _mapper;

        public UpdateExpenseCommandHandler(IExpenseService expenseService, IMapper mapper)
        {
            _expenseService = expenseService;
            _mapper = mapper;
        }

        public async Task<ExpenseResponseDto> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            var updatedExpense = await _expenseService.UpdateAsync(request.Id, request.Model);
            return _mapper.Map<ExpenseResponseDto>(updatedExpense);
        }
    }
}
