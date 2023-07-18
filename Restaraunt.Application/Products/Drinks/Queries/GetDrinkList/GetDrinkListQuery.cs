using MediatR;

namespace Restaraunt.Application.Products.Drinks.Queries.GetDrinkList
{
	public sealed record GetDrinkListQuery : IRequest<DrinkListVm>
	{
		//empty
	}
}
