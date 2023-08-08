using MediatR;

namespace Restaraunt.Application.Products.Drinks.Commands.UpdateDrink
{
	public sealed record UpdateDrinkCommand
		(Guid Id,
		string Name,
		string Description,
		double Price,
		int Size,
		bool IsCarbonated
		) : IRequest<Unit>;

}
