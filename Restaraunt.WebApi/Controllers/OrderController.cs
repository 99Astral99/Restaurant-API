using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaraunt.Application.Orders.Commands;
using Restaraunt.Application.Orders.Commands.DeleteOrder;

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

		[HttpPost]
		public async Task<ActionResult<int>> Delete(int id)
		{
			var command = new DeleteOrderCommand(id);
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
