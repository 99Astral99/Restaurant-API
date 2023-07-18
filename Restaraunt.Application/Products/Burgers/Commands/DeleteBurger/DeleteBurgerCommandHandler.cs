using MediatR;
using Microsoft.EntityFrameworkCore;
using Restaraunt.Application.Common.Exceptions;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain;

namespace Restaraunt.Application.Products.Burgers.Commands.DeleteBurger
{
    public class DeleteBurgerCommandHandler
        : IRequestHandler<DeleteBurgerCommand, Unit>
    {
        private readonly IProductDbContext _context;
        public DeleteBurgerCommandHandler(IProductDbContext context) =>
            _context = context;
        public async Task<Unit> Handle(DeleteBurgerCommand request,
            CancellationToken cancellationToken)
        {

            var entity = await _context.Burgers
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Burger), request.Id);
            }

            _context.Burgers.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
