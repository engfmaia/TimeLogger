using System;
using System.Collections.Generic;
using Timelogger.Models;

namespace Timelogger.Services.Customers
{
    public class CustomersServiceValidationDecorator : ICustomersService
    {
        private readonly ICustomersService _customersService;

        public CustomersServiceValidationDecorator(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        public CustomerDto CreateCustomer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Customer Name value must not be null or empty");
            }

            return _customersService.CreateCustomer(name);
        }

        public CustomerDto GetCustomer(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Customer Id must be higher than zero");
            }

            return _customersService.GetCustomer(id);
        }

        public ICollection<CustomerDto> GetCustomers()
        {
            return _customersService.GetCustomers();
        }
    }
}
