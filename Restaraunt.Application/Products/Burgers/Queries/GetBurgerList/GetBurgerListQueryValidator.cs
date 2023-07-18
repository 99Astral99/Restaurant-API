using FluentValidation;

namespace Restaraunt.Application.Products.Burgers.Queries.GetBurgerList
{
	public class GetBurgerListQueryValidator : AbstractValidator<GetBurgerListQuery>
	{
		public GetBurgerListQueryValidator()
		{
			//empty
		}
	}
}
