using FluentValidation;

namespace Restaraunt.Application.Orders.Commands.DeleteOrder
{
	public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
	{
		public DeleteOrderCommandValidator()
		{
			RuleFor(deleteOrderCommand =>
				deleteOrderCommand.id).NotEmpty();
		}
	}
}
