using MediatR;

namespace Restaraunt.Application.Orders.Commands.DeleteOrder
{
	public sealed record DeleteOrderCommand(int id) 
		: IRequest<Unit>;
}
