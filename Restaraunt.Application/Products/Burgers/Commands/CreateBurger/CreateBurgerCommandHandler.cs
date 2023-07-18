using MediatR;
using Restaraunt.Application.Interfaces;
using Restaraunt.Domain;

namespace Restaraunt.Application.Products.Burgers.Commands.CreateBurger
{
    public class CreateBurgerCommandHandler
        : IRequestHandler<CreateBurgerCommand, int>
    {
        private readonly IProductDbContext _context;
        public CreateBurgerCommandHandler(IProductDbContext context) =>
            _context = context;


        public async Task<int> Handle(CreateBurgerCommand request,
            CancellationToken cancellationToken)
        {
            var burger = new Burger
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Weight = request.Weight,
            };

            await _context.Burgers.AddAsync(burger, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return burger.Id;
        }
    }
}
