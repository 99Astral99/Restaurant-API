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
	public class ReservationTableController : BaseController
	{
		[AllowAnonymous]
		[HttpGet]
		public async Task<ActionResult<ReservationTableListVm>> GetAll()
		{
			var query = new GetReservationTableListQuery();
			var vm = await Mediator.Send(query);

			return vm;
		}

		[HttpGet]
		public async Task<ActionResult<ReservationTableListVm>> GetAllReserved()
		{
			var query = new GetReservedTableListQuery();
			var vm = await Mediator.Send(query);

			return vm;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<ActionResult<ReservationTableListVm>> GetAllUnreserved()
		{
			var query = new GetUnreservedTableListQuery();
			var vm = await Mediator.Send(query);

			return vm;
		}

		
		[HttpPost]
		public async Task<ActionResult<int>> Create([FromBody] CreateReservationTableCommand command)
		{
			var reservationTableId = await Mediator.Send(command);
			return reservationTableId;
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int Id)
		{
			var command = new DeleteReservationTableCommand(Id);
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] UpdateReservationTableCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
