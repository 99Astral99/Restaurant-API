using FluentValidation;

namespace Restaraunt.Application.Products.Burgers.Commands.UpdateBurger
{
	public class UpdateBurgerCommandValidator : AbstractValidator<UpdateBurgerCommand>
	{
		public UpdateBurgerCommandValidator()
		{
			RuleFor(updateburgerCommand =>
				updateburgerCommand.Id).NotEmpty();

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
