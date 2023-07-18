using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain;

namespace Restaraunt.Application.Products.Burgers.Commands.UpdateBurger
{
    public sealed class UpdateBurgerCommandHandler
        : IRequestHandler<UpdateBurgerCommand, Unit>
    {
        private readonly IProductDbContext _context;
        public UpdateBurgerCommandHandler(IProductDbContext context) =>
            _context = context;

        public async Task<Unit> Handle(UpdateBurgerCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Burgers
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Burger), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Price = request.Price;
            entity.Weight = request.Weight;

            _context.Burgers.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

