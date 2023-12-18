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
	[Produces("application/json")]
	public class OrderController : BaseController
	{
		/// <summary>
		/// Creates the order
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /order
		/// {
		/// ProductId:"0de4632b-abba-4f16-9c64-c3f6f6396ee0",
		/// Count: 3
		/// }
		/// </remarks>
		/// <paramref name="command">CreateOrderCommand object</paramref>
		/// <returns>Returns orderId (int)</returns>
		/// <response code="200">Success</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised</response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<int>> Create([FromBody] CreateOrderCommand command)
		{
			var userName = User.Identity.Name;
			command.UserName = userName;
			var orderId = await Mediator.Send(command);
			return Ok(orderId);
		}

		/// <summary>
		/// Gets the list of orders
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /order
		/// </remarks>
		/// <returns>Returns OrderListVm</returns>
		/// <response code="200">Success</response>
		/// <response code="401">Unauthorised</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<OrderListVm>> GetAll()
		{
			var query = new GetOrderListQuery(User.Identity.Name);
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		/// <summary>
		/// Updates the order
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// PUT /order
		/// {
		/// ProductId:"0de4632b-abba-4f16-9c64-c3f6f6396ee0",
		/// Count: 3
		/// }
		/// </remarks>
		/// <paramref name="command">UpdateOrderCommand object</paramref>
		/// <returns>Returns NoContent</returns>
		/// <response code="200">Success</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised</response>
		[HttpPut]
		public async Task<ActionResult<OrderListVm>> Update(UpdateOrderCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}
		/// <summary>
		/// Deletes the order
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// DELETE /order/0de4632b-abba-4f16-9c64-c3f6f6396ee0
		/// </remarks>
		/// <paramref name="id">Int id</paramref>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="404">Not Found if the object is not found by id</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised</response>
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[HttpDelete("{id}")]
		public async Task<ActionResult<int>> Delete(int id)
		{
			var command = new DeleteOrderCommand(id);
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
