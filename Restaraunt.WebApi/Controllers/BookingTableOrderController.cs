using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaraunt.Application.BookingTableOrders.Commands.CreateBookingTableOrder;
using Restaraunt.Application.BookingTableOrders.Commands.DeleteBookingTableOrder;
using Restaraunt.Application.BookingTableOrders.Commands.UpdateBookingTableOrder;
using Restaraunt.Application.BookingTableOrders.Queries.GetBookingTableOrder;

namespace Restaraunt.WebApi.Controllers
{
	[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
	[ApiController]
	public class BookingTableOrderController : BaseController
	{
		[HttpGet]
		public async Task<ActionResult<BookingTableOrderListVm>> GetAll()
		{
			var query = new GetBookingTableOrderListQuery();
			var vm = await Mediator.Send(query);
			return vm;
		}

		[AllowAnonymous]
		[HttpPost]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateBookingTableOrderCommand command)
		{
			var bookingTableOrderId = await Mediator.Send(command);
			return bookingTableOrderId;
		}

		[AllowAnonymous]
		[HttpDelete]
		public async Task<IActionResult> Delete(Guid Id)
		{
			var command = new DeleteBookingTableOrderCommand(Id);
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateBookingTableOrderCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
