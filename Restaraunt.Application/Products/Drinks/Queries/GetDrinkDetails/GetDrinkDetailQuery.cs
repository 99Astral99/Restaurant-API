using MediatR;

namespace Restaraunt.Application.Products.Drinks.Queries.GetDrinkDetails
{
	public sealed record GetDrinkDetailsQuery
		(int Id) : IRequest<DrinkDetailsVm>;
}
