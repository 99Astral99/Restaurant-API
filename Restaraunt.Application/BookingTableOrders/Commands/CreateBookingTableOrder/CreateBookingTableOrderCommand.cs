using MediatR;

namespace Restaraunt.Application.BookingTableOrders.Commands.CreateBookingTableOrder
{
    public sealed record CreateBookingTableOrderCommand
        (int TableNumber,
        string ClientName,
        int ReservedPeopleAmount,
        DateTime Date
        )
        : IRequest<Guid>;
}


