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
	[Produces("application/json")]
	public class BookingTableOrderController : BaseController
	{
		/// <summary>
		/// Gets the list of booking table orders
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /bookingtableorder
		/// </remarks>
		/// <returns>Returns BookingTableOrderListVm</returns>
		/// <response code="200">Success</response>
		/// <response code="401">Unauthorised with "Admin" role</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<BookingTableOrderListVm>> GetAll()
		{
			var query = new GetBookingTableOrderListQuery();
			var vm = await Mediator.Send(query);
			return vm;
		}

		/// <summary>
		/// Creates the booking table order
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /bookingtableorder
		/// {
		///	  tableNumber: 3,
		///	  clientName: "Mike",
		///	  reservedPeopleAmount": 5,
		///	  date": "2023-12-17T12:00:00.00Z"
		/// }
		/// </remarks>
		/// <paramref name="command">CreateBookingTableOrderCommand object</paramref>
		/// <returns>Returns bookingTableOrderId (guid)</returns>
		/// <response code="200">Success</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised with "Admin" role </response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateBookingTableOrderCommand command)
		{
			var bookingTableOrderId = await Mediator.Send(command);
			return bookingTableOrderId;
		}

		/// <summary>
		/// Deletes the booking table order
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// DELETE /bookingtableorder/981c1115-b066-4e88-a127-3216a3181b51
		/// </remarks>
		/// <paramref name="id">Guid id</paramref>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="404">Not Found if the object is not found by id</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised with "Admin" role </response>
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteBookingTableOrderCommand(id);
			await Mediator.Send(command);
			return NoContent();
		}

		/// <summary>
		/// Updates the booking table order
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// PUT /bookingtableorder
		/// {
		///		Id:"981c1115-b066-4e88-a127-3216a3181b51"
		///		tableNumber: 3,
		///		clientName: "Viktor",
		///		reservedPeopleAmount: 3,
		///		date: "2023-12-17T12:00:00.00Z"
		/// }
		/// </remarks>
		/// <paramref name="command">UpdateBookingTableOrderCommand object</paramref>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="404">Not Found if the object is not found by id</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised with "Admin" role </response>
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateBookingTableOrderCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
