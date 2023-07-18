using FluentValidation;

namespace Restaraunt.Application.Products.Burgers.Queries.GetBurgerDetails
{
	public class GetBurgerDetailsQueryValidator : AbstractValidator<GetBurgerDetailsQuery>
	{
		public GetBurgerDetailsQueryValidator()
		{
			RuleFor(burgerdetailsQuery =>
				burgerdetailsQuery.Id).NotEmpty();
		}
	}
}
