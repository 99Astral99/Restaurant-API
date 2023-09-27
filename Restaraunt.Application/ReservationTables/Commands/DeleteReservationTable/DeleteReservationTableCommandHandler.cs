using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;

namespace Restaraunt.Application.Reservation_Tables.Commands.DeleteReservationTable
{
	public class DeleteReservationTableCommandHandler
		: IRequestHandler<DeleteReservationTableCommand, Unit>
	{
		private readonly ICustomerDbContext _context;
		public DeleteReservationTableCommandHandler(ICustomerDbContext context) =>
			_context = context;
		public async Task<Unit> Handle(DeleteReservationTableCommand request,
			CancellationToken cancellationToken)
		{
			var entity = await _context.ReservationTables
				.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
			if (entity is null || entity.Id != request.Id)
				throw new NotFoundException(nameof(Table), request.Id);

			_context.ReservationTables.Remove(entity);
			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
