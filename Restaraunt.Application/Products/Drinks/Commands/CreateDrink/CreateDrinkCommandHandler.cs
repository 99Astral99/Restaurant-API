using MediatR;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Products.Drinks.Commands.CreateDrink
{
	public class CreateDrinkCommandHandler
		: IRequestHandler<CreateDrinkCommand, Guid>
	{
		private readonly IProductDbContext _context;
		public CreateDrinkCommandHandler(IProductDbContext context) =>
			_context = context;

		public async Task<Guid> Handle(CreateDrinkCommand request,
			CancellationToken cancellationToken)
		{
			var drink = new Drink
			{
				Name = request.Name,
				Description = request.Description,
				Price = request.Price,
				Size = request.Size,
				IsCarbonated = request.IsCarbonated,
			};

			await _context.Drinks.AddAsync(drink, cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);

			return drink.Id;
		}
	}
}
