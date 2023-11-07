using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;

namespace Restaraunt.Application.Reservation_Tables.Commands.UpdateReservationTable
{
	public class UpdateReservationTableCommandHandler : IRequestHandler<UpdateReservationTableCommand, Unit>
	{
		private readonly ICustomerDbContext _context;
		public UpdateReservationTableCommandHandler(ICustomerDbContext context) =>
			_context = context;


		public async Task<Unit> Handle(UpdateReservationTableCommand request,
			CancellationToken cancellationToken)
		{
			var entity = await _context.ReservationTables
				.FirstOrDefaultAsync(x => x.Id == request.Id);

			if (entity is null || entity.Id != request.Id)
			{
				throw new NotFoundException(nameof(Table), request.Id);
			}

			var existingTableNumber = await _context.ReservationTables
				.FirstOrDefaultAsync(x => x.Number == request.Number);
			if (existingTableNumber != null) { throw new ArgumentException($"The reservation table with number: {request.Number} already exists by ID: {existingTableNumber.Id}"); }

			entity.Number = request.Number;
			entity.IsReserved = request.IsReserved;

			_context.ReservationTables.Update(entity);
			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
