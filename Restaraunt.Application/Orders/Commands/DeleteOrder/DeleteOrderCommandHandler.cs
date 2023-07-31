using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain;

namespace Restaraunt.Application.Orders.Commands.DeleteOrder
{
	public class DeleteOrderCommandHandler
		: IRequestHandler<DeleteOrderCommand, Unit>
	{
		private readonly ICustomerDbContext _context;
		public DeleteOrderCommandHandler(ICustomerDbContext context) =>
			_context = context;

		public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
		{
			var entity = await _context.Orders
				.Select(x => x.Cart.Orders.FirstOrDefault(x => x.Id == request.id))
				.FirstOrDefaultAsync(x => x.Id == request.id, cancellationToken);

			//		var order = _orderRepository.GetAll()
			//.Select(x => x.Cart.Orders.FirstOrDefault(x => x.Id == id))
			//.FirstOrDefault(x => x.Id == id);

			if (entity is null || entity.Id != request.id)
			{
				throw new NotFoundException(nameof(Burger), request.id);
			}

			_context.Orders.Remove(entity);
			await _context.SaveChangesAsync(cancellationToken);
			return Unit.Value;
		}
	}
}
