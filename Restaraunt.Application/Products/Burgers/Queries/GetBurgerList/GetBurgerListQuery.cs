using MediatR;

namespace Restaraunt.Application.Products.Burgers.Queries.GetBurgerList
{
	public sealed record GetBurgerListQuery : IRequest<BurgerListVm>
	{
		//empty
	}
}
