using MediatR;

namespace Restaraunt.Application.BookingTableOrders.Commands.DeleteBookingTableOrder
{
	public sealed record DeleteBookingTableOrderCommand
		(Guid Id) : IRequest<Unit>;
}
