using FluentValidation;

namespace Restaraunt.Application.Orders.Commands.UpdateOrder
{
	public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
	{
		public UpdateOrderCommandValidator()
		{
			RuleFor(updateOrderCommand =>
			updateOrderCommand.Id).NotEmpty();

			RuleFor(updateOrderCommand =>
			updateOrderCommand.Count).NotEmpty().GreaterThan(0);
		}
	}
}
