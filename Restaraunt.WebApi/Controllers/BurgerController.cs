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
	public class BurgerController : BaseController
	{
		[HttpGet]
		public async Task<ActionResult<BurgerListVm>> GetAll()
		{
			var query = new GetBurgerListQuery();
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<BurgerDetailsVm>> Get(Guid id)
		{
			var query = new GetBurgerDetailsQuery(id);
			var vm = await Mediator.Send(query);

			return Ok(vm);
		}

		[HttpPost]
		public async Task<ActionResult<Guid>> Create([FromBody] CreateBurgerCommand command)
		{
			var burgerId = await Mediator.Send(command);
			return burgerId;
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateBurgerCommand command)
		{
			await Mediator.Send(command);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var command = new DeleteBurgerCommand(id);
			await Mediator.Send(command);
			return NoContent();
		}
	}
}
