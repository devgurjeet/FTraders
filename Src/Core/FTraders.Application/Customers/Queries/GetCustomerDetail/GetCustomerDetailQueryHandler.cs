using FTraders.Application.Exceptions;
using FTraders.Application.Interfaces;
using FTraders.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTraders.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailModel>
    {
        private readonly IFTradersDbContext _context;

        public GetCustomerDetailQueryHandler(IFTradersDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDetailModel> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            return CustomerDetailModel.Create(entity);
        }
    }
}
