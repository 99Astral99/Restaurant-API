using AutoMapper;
using AutoMapper.QueryableExtensions;
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
				.Include(x => x.Cart)
				.ThenInclude(x => x.Orders)
				.FirstOrDefaultAsync(x => x.UserName == request.userName);

			if (user is null || user.UserName != request.userName)
				throw new NotFoundException(nameof(User), request.userName);

			//var orders = user.Cart?.Orders;

			var orderListVm = await _customerContext.Orders
				.Where(x => x.CartId == user.Cart.Id)
				.ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
				.ToListAsync(cancellationToken);

			return new OrderListVm { Orders = orderListVm };
		}
	}
}
