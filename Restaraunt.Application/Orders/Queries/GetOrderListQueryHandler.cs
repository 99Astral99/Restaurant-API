using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities.Identity;

namespace Restaraunt.Application.Orders.Queries
{
	public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderListVm>
	{
		private readonly ICustomerDbContext _customerContext;
		private readonly IProductDbContext _productContext;
		private readonly UserManager<User> _userManager;
		private readonly IMapper _mapper;
		public GetOrderListQueryHandler(ICustomerDbContext context, IProductDbContext productContext,
			UserManager<User> userManager, IMapper mapper) =>
			(_customerContext, _productContext, _userManager, _mapper) = (context, productContext, userManager, mapper);


		public async Task<OrderListVm> Handle(GetOrderListQuery request,
			CancellationToken cancellationToken)
		{
			var user = await _userManager.Users
				.AsNoTracking()
				.Include(x => x.Cart)
				.ThenInclude(x => x.Orders)
				.FirstOrDefaultAsync(x => x.UserName == request.userName);

			if (user is null || user.UserName != request.userName)
				throw new NotFoundException(nameof(User), request.userName);

			var orders = user.Cart?.Orders;

			var burgersQuery = from o in orders
							   join p in _productContext.Burgers on o.ProductId equals p.Id
							   select new OrderLookupDto
							   {
								   Id = o.Id,
								   ProductId = o.ProductId,
								   ProductName = p.Name,
								   ProductPrice = p.Price * o.Count,
								   Count = o.Count,

							   };

			var drinksQuery = from o in orders
							  join p in _productContext.Drinks on o.ProductId equals p.Id
							  select new OrderLookupDto
							  {
								  Id = o.Id,
								  ProductId = o.ProductId,
								  ProductName = p.Name,
								  ProductPrice = p.Price * o.Count,
								  Count = o.Count
							  };

			var res = burgersQuery.Union(drinksQuery).ToList();

			return new OrderListVm { Orders = res };
		}
	}
}
