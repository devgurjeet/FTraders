using System.Collections.Generic;

namespace FTraders.Application.Customers.Queries.GetCustomersList
{
    public class CustomersListViewModel
    {
        public IList<CustomerLookupModel> Customers { get; set; }
    }
}
