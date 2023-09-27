using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.BookingTableOrders.Commands.CreateBookingTableOrder
{
	public class CreateBookingTableOrdersCommandHandler : IRequestHandler<CreateBookingTableOrderCommand, Guid>
	{
		private readonly ICustomerDbContext _context;
		public CreateBookingTableOrdersCommandHandler(ICustomerDbContext context) =>
			_context = context;

		public async Task<Guid> Handle(CreateBookingTableOrderCommand request,
			CancellationToken cancellationToken)
		{
			var existBookingOrder = await _context.BookingTableOrders
				.Include(x => x.ReservationTable)
				.FirstOrDefaultAsync(x => x.ClientName == request.ClientName
				&& x.ReservationTable.Number == request.TableNumber);

			if (existBookingOrder != null && existBookingOrder.ReservationTable.IsReserved == true)
			{ throw new ArgumentException($"Table with {request.TableNumber} number is already reserved"); }


			var reservedTable = await _context.ReservationTables.FirstOrDefaultAsync(x => x.Number == request.TableNumber);
			if (reservedTable == null)
				throw new NotFoundException(nameof(ReservationTable), request.TableNumber);
			reservedTable.IsReserved = true;

			var bookingTableOrder = new BookingTableOrder
			{
				ReservedPeopleAmount = request.ReservedPeopleAmount,
				ClientName = request.ClientName,
				TableNumber = request.TableNumber,
				Date = request.Date,
				ReservationTable = reservedTable
			};

			await _context.BookingTableOrders.AddAsync(bookingTableOrder, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);

			return bookingTableOrder.Id;
		}
	}
}
