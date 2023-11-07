using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.BookingTableOrders.Commands.DeleteBookingTableOrder
{
	public class DeleteBookingTableOrderCommandHandler : IRequestHandler<DeleteBookingTableOrderCommand, Unit>
	{
		private readonly ICustomerDbContext _context;
		public DeleteBookingTableOrderCommandHandler(ICustomerDbContext context) =>
			_context = context;
		public async Task<Unit> Handle(DeleteBookingTableOrderCommand request, CancellationToken cancellationToken)
		{
			var entity = await _context.BookingTableOrders.FirstOrDefaultAsync(x => x.Id == request.Id);
			if (entity == null) 
			{
				throw new NotFoundException(nameof(BookingTableOrder), request.Id);
			}

			_context.BookingTableOrders.Remove(entity);
			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
