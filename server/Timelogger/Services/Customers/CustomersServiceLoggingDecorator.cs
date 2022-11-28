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
            _customersService = customersService;
            _logger = logger;
        }

        public CustomerDto CreateCustomer(string name)
        {
            _logger.LogDebug($"Customer creation started: Name {name}", DateTime.UtcNow.ToLongTimeString());

            try
            {
                var customer = _customersService.CreateCustomer(name);
                _logger.LogDebug("Customer creation finished", DateTime.UtcNow.ToLongTimeString());
                return customer;
            }
            catch (Exception exception)
            {
                _logger.LogDebug($"Customer creation finished: Name {name} and throwed exception {exception.GetType()} - {exception.Message}", DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }

        public CustomerDto GetCustomer(int id)
        {
            _logger.LogDebug($"Customer retrieval started: Id {id}", DateTime.UtcNow.ToLongTimeString());

            try
            {
                var customer = _customersService.GetCustomer(id);
                _logger.LogDebug($"Customer retrieval finished: Id {id}", DateTime.UtcNow.ToLongTimeString());
                return customer;
            }
            catch (Exception exception)
            {
                _logger.LogDebug($"Customer retrieval finished: Id {id} and throwed exception {exception.GetType()} - {exception.Message}", DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }

        public ICollection<CustomerDto> GetCustomers()
        {
            _logger.LogDebug("Customers retrieval started", DateTime.UtcNow.ToLongTimeString());

            try
            {
                var customers = _customersService.GetCustomers();
                _logger.LogDebug("Customers retrieval finished", DateTime.UtcNow.ToLongTimeString());
                return customers;
            }
            catch (Exception exception)
            {
                _logger.LogDebug($"Customer retrieval finished and throwed exception {exception.GetType()} - {exception.Message}", DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }
    }
}
