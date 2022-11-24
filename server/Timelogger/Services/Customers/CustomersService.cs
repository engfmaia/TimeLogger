using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;
using Timelogger.Models;

namespace Timelogger.Services.Customers
{
    public class CustomersService : ICustomersService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public CustomersService(ApiContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public CustomerDto CreateCustomer(string name)
        {
            var customer = _context.Customers.Add(new Customer { Name = name });
            _context.SaveChanges();

            return _mapper.Map<CustomerDto>(customer.Entity);
        }

        public CustomerDto GetCustomer(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException("Id should be higher than zero");

            var customer = _context.Customers.Find(id);

            if (customer == null)
                throw new NullReferenceException("Customer does not exist");

            return _mapper.Map<CustomerDto>(customer);
        }

        public ICollection<CustomerDto> GetCustomers()
        {
            return _context
                    .Customers
                    .Select(customer => _mapper.Map<CustomerDto>(customer))
                    .ToList();
        }
    }
}