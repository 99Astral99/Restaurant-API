using MediatR;

namespace Restaraunt.Application.BookingTableOrders.Commands.UpdateBookingTableOrder
{
	public sealed record UpdateBookingTableOrderCommand
		(
		Guid Id,
		int TableNumber,
		string ClientName,
		int ReservedPeopleAmount,
		DateTime Date
		) :IRequest<Unit>;
}
