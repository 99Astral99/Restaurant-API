using FluentValidation;

namespace Restaraunt.Application.Products.Burgers.Commands.CreateBurger
{
	public class CreateBurgerCommandValidator : AbstractValidator<CreateBurgerCommand>
	{
		public CreateBurgerCommandValidator()
		{
			RuleFor(updateburgerCommand =>
				updateburgerCommand.Name).NotEmpty().MaximumLength(50);

			RuleFor(createBurgerCommand =>
				createBurgerCommand.Price).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);

			RuleFor(updateburgerCommand =>
				updateburgerCommand.Description).NotEmpty().MaximumLength(700);

			RuleFor(updateburgerCommand =>
				updateburgerCommand.Weight).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(1000);
		}
	}
}
