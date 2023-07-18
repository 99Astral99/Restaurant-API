using FluentValidation;

namespace Restaraunt.Application.Products.Drinks.Commands.DeleteDrink
{
	public class DeleteDrinkValidator : AbstractValidator<DeleteDrinkCommand>
	{
		public DeleteDrinkValidator()
		{
			RuleFor(deletedrinkCommand =>
				deletedrinkCommand.Id).NotEmpty();
		}
	}
}
