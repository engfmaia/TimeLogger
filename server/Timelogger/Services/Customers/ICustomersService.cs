using System.Collections.Generic;
using Timelogger.Models;

namespace Timelogger.Services.Customers
{
    public interface ICustomersService
    {
        public CustomerDto GetCustomer(int id);

        public ICollection<CustomerDto> GetCustomers();

        public CustomerDto CreateCustomer(string name);
    }
}