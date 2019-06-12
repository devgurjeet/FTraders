using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FTraders.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListViewModel>
    {
    }
}
