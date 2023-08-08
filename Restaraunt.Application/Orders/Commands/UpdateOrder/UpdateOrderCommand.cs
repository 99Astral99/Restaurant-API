using MediatR;

namespace Restaraunt.Application.Orders.Commands.UpdateOrder
{
	public sealed record UpdateOrderCommand
		(int Id,
		int Count
		) : IRequest<Unit>;
}
