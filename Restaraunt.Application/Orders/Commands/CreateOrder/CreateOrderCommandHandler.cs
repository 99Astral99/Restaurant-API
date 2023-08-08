using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities;
using Restaraunt.Domain.Entities.Identity;

namespace Restaraunt.Application.Orders.Commands
{
	public class CreateOrderCommandHandler
		: IRequestHandler<CreateOrderCommand, int>
	{
		private readonly ICustomerDbContext _context;
		private readonly UserManager<User> _userManager;

		public CreateOrderCommandHandler(ICustomerDbContext context, UserManager<User> userManager) =>
			(_context, _userManager) = (context, userManager);
		public async Task<int> Handle(CreateOrderCommand request,
			CancellationToken cancellationToken)
		{
			var user = await _userManager.Users
				.Include(x => x.Cart)
				.FirstOrDefaultAsync(x => x.UserName == request.UserName);

			if (user is null || user.UserName != request.UserName)
				throw new NotFoundException(nameof(User), request.UserName);

			var existOrder = await _context.Orders.FirstOrDefaultAsync(x => x.ProductId == request.ProductId);
			if (existOrder != null)
			{
				existOrder.Count += request.Count;
			}

			else
			{
				var order = new Order
				{
					ProductId = request.ProductId,
					CartId = user.Cart.Id,
					Count = request.Count,
					DateCreated = DateTime.UtcNow,
					UserName = request.UserName,
				};

				await _context.Orders.AddAsync(order, cancellationToken);
				await _context.SaveChangesAsync(cancellationToken);

				return order.Id;
			}

			await _context.SaveChangesAsync(cancellationToken);
			return existOrder.Id;
		}

	}
}
