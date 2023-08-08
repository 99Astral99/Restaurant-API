using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Orders.Commands.UpdateOrder
{
	public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
	{
		private readonly ICustomerDbContext _context;
		public UpdateOrderCommandHandler(ICustomerDbContext context) =>
			_context = context;

		public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
		{
			var entity = await _context.Orders.FirstOrDefaultAsync(x => x.Id == request.Id);

			if (entity is null || entity.Id != request.Id)
			{
				throw new NotFoundException(nameof(Order), request.Id);
			}

			entity.Count = request.Count;

			_context.Orders.Update(entity);
			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
