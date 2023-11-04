using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain;
using Restaraunt.Domain.Entities;

namespace Restaraunt.Application.Products.Drinks.Commands.DeleteDrink
{
	public class DeleteDrinkCommandHandler :
		IRequestHandler<DeleteDrinkCommand, Unit>
	{
		private readonly IProductDbContext _context;
		public DeleteDrinkCommandHandler(IProductDbContext context) =>
			_context = context;
		public async Task<Unit> Handle(DeleteDrinkCommand request,
			CancellationToken cancellationToken)
		{

			var entity = await _context.Drinks
				.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

			if (entity is null || entity.Id != request.Id)
			{
				throw new NotFoundException(nameof(Drink), request.Id);
			}

			_context.Drinks.Remove(entity);
			await _context.SaveChangesAsync(cancellationToken);
			return Unit.Value;
		}
	}
}
