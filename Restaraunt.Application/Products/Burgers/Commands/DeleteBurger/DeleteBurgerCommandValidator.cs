using FluentValidation;

namespace Restaraunt.Application.Products.Burgers.Commands.DeleteBurger
{
	public class DeleteBurgerCommandValidator : AbstractValidator<DeleteBurgerCommand>
	{
		public DeleteBurgerCommandValidator()
		{
			RuleFor(deleteburgerCommand =>
				deleteburgerCommand.Id).NotEmpty();
		}
	}
}
