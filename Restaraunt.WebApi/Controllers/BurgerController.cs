using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaraunt.Application.Products.Burgers.Commands.CreateBurger;
using Restaraunt.Application.Products.Burgers.Commands.DeleteBurger;
using Restaraunt.Application.Products.Burgers.Commands.UpdateBurger;
using Restaraunt.Application.Products.Burgers.Queries.GetBurgerDetails;
using Restaraunt.Application.Products.Burgers.Queries.GetBurgerList;

namespace Restaraunt.WebApi.Controllers
{
	[ApiController]
	[Produces("application/json")]
	public class BurgerController : BaseController
	{
		/// <summary>
		/// Gets the list of burgers
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /burger
		/// </remarks>
		/// <returns>Returns BurgerListVm</returns>
		/// <response code="200">Success</response>
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<BurgerListVm>> GetAll()
		{
			var query = new GetBurgerListQuery();
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		/// <summary>
		/// Gets the burger by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /burger/0de4632b-abba-4f16-9c64-c3f6f6396ee0
		/// </remarks>
		/// <paramref name="id">Burger id(guid)</paramref>
		/// <returns>Returns BurgerDetailsVm</returns>
		/// <response code="200">Success</response>
		/// <response code="404">Not Found</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<BurgerDetailsVm>> Get(Guid id)
		{
			var query = new GetBurgerDetailsQuery(id);
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		/// <summary>
		/// Creates the burger
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /burger
		/// {
		///		Name:"burger",
		///		Description:"burger description",
		///		Price: 2.5,
		///		Weight:320
		/// }
		/// </remarks>
		/// <paramref name="command">CreateBurgerCommand object</paramref>
		/// <returns>Returns Burger id (guid)</returns>
		/// <response code="200">Success</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateBurgerCommand command)
		{
			var burgerId = await Mediator.Send(command);
			return burgerId;
		}

		/// <summary>
		/// Updates the burger
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// PUT /burger
		/// {
		///		Id:"0de4632b-abba-4f16-9c64-c3f6f6396ee0",
		///		Name:"burger",
		///		Description:"burger description",
		///		Price: 2.5,
		///		Weight:320
		/// }
		/// </remarks>
		/// <paramref name="command">UpdateBurgerCommand object</paramref>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="404">Not Found if the object is not found by id</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update(UpdateBurgerCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		/// <summary>
		/// Deletes the burger
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// DELETE /burger/0de4632b-abba-4f16-9c64-c3f6f6396ee0
		/// </remarks>
		/// <paramref name="id">Guid id</paramref>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="404">Not Found if the object is not found by id</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteBurgerCommand(id);
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
