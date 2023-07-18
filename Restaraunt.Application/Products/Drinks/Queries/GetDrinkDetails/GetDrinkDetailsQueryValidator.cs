using FluentValidation;

namespace Restaraunt.Application.Products.Drinks.Queries.GetDrinkDetails
{
	public class GetDrinkDetailsQueryValidator : AbstractValidator<GetDrinkDetailsQuery>
	{
		public GetDrinkDetailsQueryValidator()
		{
			RuleFor(drinkdetailsQuery =>
				drinkdetailsQuery.Id).NotEmpty();
		}
	}
}
