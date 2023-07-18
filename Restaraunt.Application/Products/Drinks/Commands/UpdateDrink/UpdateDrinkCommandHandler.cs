using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Products.Drinks.Commands.UpdateDrink
{
	public class UpdateDrinkCommandHandler :
		IRequestHandler<UpdateDrinkCommand, Unit>
	{
		private readonly IProductDbContext _context;
		public UpdateDrinkCommandHandler(IProductDbContext context) =>
			_context = context;

		public async Task<Unit> Handle(UpdateDrinkCommand request,
			CancellationToken cancellationToken)
		{
			var entity = await _context.Drinks
				.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

			if (entity is null || entity.Id != request.Id)
			{
				throw new NotFoundException(nameof(Drink), request.Id);
			}

			entity.Name = request.Name;
			entity.Description = request.Description;
			entity.Price = request.Price;
			entity.Size = request.Size;
			entity.IsCarbonated = request.IsCarbonated;

			_context.Drinks.Update(entity);
			await _context.SaveChangesAsync(cancellationToken);

			return Unit.Value;
		}
	}
}
