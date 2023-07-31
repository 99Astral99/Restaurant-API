using FluentValidation;

namespace Restaraunt.Application.Orders.Commands
{
	public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
	{
		public CreateOrderCommandValidator()
		{
			RuleFor(createOrderCommand =>
				createOrderCommand.ProductId).NotEmpty();

			RuleFor(createOrderCommand =>
				createOrderCommand.Count).NotEmpty().GreaterThan(0);
		}
	}
}
