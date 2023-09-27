using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;

namespace Restaraunt.Application.BookingTableOrders.Commands.UpdateBookingTableOrder
{
	public class UpdateBookingTableOrderCommandHandler : IRequestHandler<UpdateBookingTableOrderCommand, Unit>
	{
		private readonly ICustomerDbContext _context;
		public UpdateBookingTableOrderCommandHandler(ICustomerDbContext context) =>
			_context = context;
		public async Task<Unit> Handle(UpdateBookingTableOrderCommand request,
			CancellationToken cancellationToken)
		{
			var entity = await _context.BookingTableOrders
				.FirstOrDefaultAsync(x => x.Id == request.Id);

			if (entity is null || entity.Id != request.Id)
			{
				throw new NotFoundException(nameof(Table), request.Id);
			}

			entity.ReservedPeopleAmount = request.ReservedPeopleAmount;
			entity.TableNumber = request.TableNumber;
			entity.ClientName = request.ClientName;
			entity.Date = request.Date;
			entity.ReservationTable = await _context.ReservationTables
				.FirstOrDefaultAsync(x => x.Number == request.TableNumber);

			_context.BookingTableOrders.Update(entity);
			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
