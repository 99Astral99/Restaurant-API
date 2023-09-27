using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.ReservationTables.Commands
{
	public class CreateReservationTableCommandHandler : IRequestHandler<CreateReservationTableCommand, int>
	{
		private readonly ICustomerDbContext _context;
		public CreateReservationTableCommandHandler(ICustomerDbContext context) =>
			_context = context;

		public async Task<int> Handle(CreateReservationTableCommand request,
			CancellationToken cancellationToken)
		{
			var existTable = await _context.ReservationTables.FirstOrDefaultAsync(x => x.Number == request.Number);
			if (existTable != null) { throw new ArgumentException($"The reservation table with number: {request.Number} already exists by ID: {existTable.Id}"); }

			var table = new ReservationTable
			{
				Number = request.Number,
				IsReserved = false,
			};

			await _context.ReservationTables.AddAsync(table, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);
			return table.Id;
		}
	}
}
