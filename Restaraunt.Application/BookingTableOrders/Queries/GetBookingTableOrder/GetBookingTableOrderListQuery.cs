using MediatR;

namespace Restaraunt.Application.BookingTableOrders.Queries.GetBookingTableOrder
{
	public sealed record GetBookingTableOrderListQuery : IRequest<BookingTableOrderListVm>;
}
