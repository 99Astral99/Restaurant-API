using MediatR;

namespace Restaraunt.Application.Products.Drinks.Commands.CreateDrink
{
	public sealed record CreateDrinkCommand
		(Guid Id,
		string Name,
		string Description,
		double Price,
		int Size,
		bool IsCarbonated
		)
		: IRequest<Guid>;
}
