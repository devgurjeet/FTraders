using AutoMapper;
using FTraders.Application.Exceptions;
using FTraders.Application.Interfaces;
using FTraders.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FTraders.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly IFTradersDbContext _context;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(
            IFTradersDbContext context, 
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductViewModel>(await _context
                .Products.Where(p => p.ProductId == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            // TODO: Set view model state based on user permissions.
            product.EditEnabled = true;
            product.DeleteEnabled = false;

            return product;
        }

    }
}
