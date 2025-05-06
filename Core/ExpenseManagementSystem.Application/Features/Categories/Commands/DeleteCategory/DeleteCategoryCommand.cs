using MediatR;

namespace ExpenseManagementSystem.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public DeleteCategoryCommand(long id)
        {
            Id = id;
        }
    }
}
