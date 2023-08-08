using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaraunt.Application.Orders.Commands;
using Restaraunt.Application.Orders.Commands.DeleteOrder;
using Restaraunt.Application.Orders.Commands.UpdateOrder;
using Restaraunt.Application.Orders.Queries;

namespace Restaraunt.WebApi.Controllers
{
	[Authorize]
	[ApiController]
	public class OrderController : BaseController
	{
		[HttpPost]
		public async Task<ActionResult<int>> Create([FromBody] CreateOrderCommand command)
		{
			var userName = User.Identity.Name;
			command.UserName = userName;
			var orderId = await Mediator.Send(command);
			return Ok(orderId);
		}

		[HttpGet]
		public async Task<ActionResult<OrderListVm>> GetAll()
		{
			var query = new GetOrderListQuery(User.Identity.Name);
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		[HttpPut]
		public async Task<ActionResult<OrderListVm>> UpdateOrder(UpdateOrderCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPost]
		public async Task<ActionResult<int>> Delete(int id)
		{
			var command = new DeleteOrderCommand(id);
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
