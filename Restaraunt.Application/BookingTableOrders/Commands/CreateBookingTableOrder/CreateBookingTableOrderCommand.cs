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



//public Guid Id { get; set; }
//public int ReservationTableId { get; set; }
//public virtual ReservationTable ReservationTable { get; set; }
//public int TableNumber { get; set; }
//public string ClientName { get; set; }
//public int ReservedPeopleAmount { get; set; }
//public DateTime Date { get; set; }
