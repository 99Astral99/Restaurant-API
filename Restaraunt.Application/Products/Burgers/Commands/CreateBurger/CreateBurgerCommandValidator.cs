using FluentValidation;

namespace Restaraunt.Application.Products.Burgers.Commands.CreateBurger
{
	public class CreateBurgerCommandValidator : AbstractValidator<CreateBurgerCommand>
	{
		public CreateBurgerCommandValidator()
		{
			RuleFor(createBurgerCommand =>
				createBurgerCommand.Name).NotEmpty().MaximumLength(50);

			RuleFor(createBurgerCommand =>
				createBurgerCommand.Price).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);

			RuleFor(createBurgerCommand =>
				createBurgerCommand.Description).NotEmpty().MaximumLength(700);

			RuleFor(createBurgerCommand =>
				createBurgerCommand.Weight).NotEmpty().GreaterThanOrEqualTo(0).LessThanOrEqualTo(1000);
		}
	}
}
