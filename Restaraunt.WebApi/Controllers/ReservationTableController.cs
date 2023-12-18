using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaraunt.Application.Reservation_Tables.Commands.DeleteReservationTable;
using Restaraunt.Application.Reservation_Tables.Commands.UpdateReservationTable;
using Restaraunt.Application.Reservation_Tables.Queries;
using Restaraunt.Application.ReservationTables.Commands;
using Restaraunt.Application.ReservationTables.Queries.GetReservedTableList;

namespace Restaraunt.WebApi.Controllers
{
	[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
	[ApiController]
	[Produces("application/json")]
	public class ReservationTableController : BaseController
	{
		/// <summary>
		/// Gets the list of reservation tables
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /reservationtable
		/// </remarks>
		/// <returns>Returns ReservationTableListVm</returns>
		/// <response code="200">Success</response>
		[HttpGet]
		[AllowAnonymous]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<ReservationTableListVm>> GetAll()
		{
			var query = new GetReservationTableListQuery();
			var vm = await Mediator.Send(query);

			return vm;
		}

		/// <summary>
		/// Gets the list of reservation tables
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /reservationtable/getallreserved
		/// </remarks>
		/// <returns>Returns ReservationTableListVm</returns>
		/// <response code="200">Success</response>
		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<ReservationTableListVm>> GetAllReserved()
		{
			var query = new GetReservedTableListQuery();
			var vm = await Mediator.Send(query);

			return vm;
		}

		/// <summary>
		/// Gets the list of reservation tables
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /reservationtable/getallunreserved
		/// </remarks>
		/// <returns>Returns ReservationTableListVm</returns>
		/// <response code="200">Success</response>
		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<ReservationTableListVm>> GetAllUnreserved()
		{
			var query = new GetUnreservedTableListQuery();
			var vm = await Mediator.Send(query);

			return vm;
		}


		/// <summary>
		/// Creates the reservation table
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /reservationtable
		/// {
		///	  Number: 3
		/// }
		/// </remarks>
		/// <paramref name="command">CreateReservationTableCommand object</paramref>
		/// <returns>Returns bookingTableOrderId (int)</returns>
		/// <response code="200">Success</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised with "Admin" role </response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<int>> Create([FromBody] CreateReservationTableCommand command)
		{
			var reservationTableId = await Mediator.Send(command);
			return reservationTableId;
		}

		/// <summary>
		/// Deletes the reservation table 
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// DELETE /reservationtable/3
		/// </remarks>
		/// <paramref name="id">Int id</paramref>
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
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteReservationTableCommand(id);
			await Mediator.Send(command);
			return NoContent();
		}
		/// <summary>
		/// Updates the reservation table
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// PUT /reservationtable
		/// {
		///	  Number: 3
		/// }
		/// </remarks>
		/// <paramref name="command">UpdateReservationTableCommand object</paramref>
		/// <returns>Returns NoContent</returns>
		/// <response code="200">Success</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		/// <response code="401">Unauthorised with "Admin" role </response>
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<IActionResult> Update([FromBody] UpdateReservationTableCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
