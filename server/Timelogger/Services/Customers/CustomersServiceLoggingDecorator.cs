using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Timelogger.Models;

namespace Timelogger.Services.Customers
{
    public class CustomersServiceLoggingDecorator : ICustomersService
    {
        private readonly ICustomersService _customersService;
        private readonly ILogger<CustomersServiceLoggingDecorator> _logger;

        public CustomersServiceLoggingDecorator(ICustomersService customersService, ILogger<CustomersServiceLoggingDecorator> logger)
        {
            this._customersService = customersService;
            this._logger = logger;
        }

        public CustomerDto CreateCustomer(string name)
        {
            _logger.LogDebug("Customer creation started", DateTime.UtcNow.ToLongTimeString());

            var customer = _customersService.CreateCustomer(name);

            _logger.LogDebug("Customer creation finished", DateTime.UtcNow.ToLongTimeString());

            return customer;
        }

        public CustomerDto GetCustomer(int id)
        {
            _logger.LogDebug("Customer retrieval", DateTime.UtcNow.ToLongTimeString());

            return _customersService.GetCustomer(id);
        }

        public ICollection<CustomerDto> GetCustomers()
        {
            _logger.LogDebug("Customers retrieval", DateTime.UtcNow.ToLongTimeString());

            return _customersService.GetCustomers();
        }
    }
}
