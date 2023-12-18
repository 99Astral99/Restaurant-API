using Microsoft.AspNetCore.Mvc;
using Restaraunt.Application.Products.Drinks.Commands.CreateDrink;
using Restaraunt.Application.Products.Drinks.Commands.DeleteDrink;
using Restaraunt.Application.Products.Drinks.Commands.UpdateDrink;
using Restaraunt.Application.Products.Drinks.Queries.GetDrinkDetails;
using Restaraunt.Application.Products.Drinks.Queries.GetDrinkList;

namespace Restaraunt.WebApi.Controllers
{
	[ApiController]
	[Produces("application/json")]
	public class DrinkController : BaseController
	{
		/// <summary>
		/// Gets the list of drinks
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /drink
		/// </remarks>
		/// <returns>Returns DrinkListVm</returns>
		/// <response code="200">Success</response>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[HttpGet]
		public async Task<ActionResult<DrinkListVm>> GetAll()
		{
			var query = new GetDrinkListQuery();
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		/// <summary>
		/// Gets the drink by id
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// GET /drink/0de4632b-abba-4f16-9c64-c3f6f6396ee0
		/// </remarks>
		/// <paramref name="id">Drink id(guid)</paramref>
		/// <returns>Returns DrinkDetails</returns>
		/// <response code="200">Success</response>
		/// <response code="404">Not Found</response>
		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<ActionResult<DrinkDetailsVm>> Get(Guid id)
		{
			var query = new GetDrinkDetailsQuery(id);
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		/// <summary>
		/// Creates the drink
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// POST /drink
		/// {
		///		Name:"Capuccino",
		///		Description:"A fragrant coffee drink with a delicate milk foam.",
		///		Price: 1.75,
		///		Size:100,
		///		IsCarbonated:true
		/// }
		/// </remarks>
		/// <paramref name="command">CreateDrinkCommand object</paramref>
		/// <returns>Returns Burger id (guid)</returns>
		/// <response code="200">Success</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateDrinkCommand command)
		{
			var drinkId = await Mediator.Send(command);
			return drinkId;
		}
		/// <summary>
		/// Updates the drink
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// PUT /drink
		/// {
		///		Name:"Capuccino",
		///		Description:"A fragrant coffee drink with a delicate milk foam.",
		///		Price: 1.75,
		///		Size:100,
		///		IsCarbonated:true
		/// }
		/// </remarks>
		/// <paramref name="command">UpdateDrinkCommand object</paramref>
		/// <returns>Returns NoContent</returns>
		/// <response code="204">Success</response>
		/// <response code="404">Not Found if the object is not found by id</response>
		/// <response code="400">Bad request if the credentials were entered incorrectly </response>
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Update(UpdateDrinkCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		/// <summary>
		/// Deletes the drink
		/// </summary>
		/// <remarks>
		/// Sample request:
		/// DELETE /drink/0de4632b-abba-4f16-9c64-c3f6f6396ee0
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
			var command = new DeleteDrinkCommand(id);
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
