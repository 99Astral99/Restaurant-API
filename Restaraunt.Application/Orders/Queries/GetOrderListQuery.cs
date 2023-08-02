using MediatR;

namespace Restaraunt.Application.Orders.Queries
{
	public sealed record GetOrderListQuery(string userName) : IRequest<OrderListVm>;
}
