using FTraders.Application.Exceptions;
using FTraders.Application.Interfaces;
using FTraders.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FTraders.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly IFTradersDbContext _context;

        public DeleteCustomerCommandHandler(IFTradersDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            var hasOrders = _context.Orders.Any(o => o.CustomerId == entity.CustomerId);
            if (hasOrders)
            {
                // TODO: Add functional test for this behaviour.
                throw new DeleteFailureException(nameof(Customer), request.Id, "There are existing orders associated with this customer.");
            }

            _context.Customers.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
