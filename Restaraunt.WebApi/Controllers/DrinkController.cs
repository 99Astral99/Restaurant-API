using Microsoft.AspNetCore.Mvc;
using Restaraunt.Application.Products.Drinks.Commands.CreateDrink;
using Restaraunt.Application.Products.Drinks.Commands.DeleteDrink;
using Restaraunt.Application.Products.Drinks.Commands.UpdateDrink;
using Restaraunt.Application.Products.Drinks.Queries.GetDrinkDetails;
using Restaraunt.Application.Products.Drinks.Queries.GetDrinkList;

namespace Restaraunt.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DrinkController : BaseController
	{
		[HttpGet]
		public async Task<ActionResult<DrinkListVm>> GetAll()
		{
			var query = new GetDrinkListQuery();
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<DrinkDetailsVm>> Get(int id)
		{
			var query = new GetDrinkDetailsQuery(id);
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		[HttpPost]
		public async Task<ActionResult<int>> Create([FromBody] CreateDrinkCommand command)
		{
			var drinkId = await Mediator.Send(command);
			return drinkId;
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateDrinkCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var command = new DeleteDrinkCommand(id);
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
