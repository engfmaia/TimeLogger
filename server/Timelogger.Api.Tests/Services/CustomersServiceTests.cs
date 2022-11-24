using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using Timelogger.Entities;
using Timelogger.Mappers;
using Timelogger.Services.Customers;

namespace Timelogger.Api.Tests
{
    public class CustomersServiceTests
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        private readonly ICustomersService _customersService;

        public CustomersServiceTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _context = new ApiContext(options);
            _context.Database.EnsureCreated();

            _customersService = new CustomersService(_context, _mapper);
        }

        [Test]
        public void QueryingCustomerIdLowerThanZero_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _customersService.GetCustomer(-1),
                Throws.Exception
                  .TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void QueryingProjectWithExistingId_Should_ReturnCorrectlyMappedDto()
        {
            CreateMockCustomer(123, "MockCustomer 123");

            var customer = _customersService.GetCustomer(123);
            Assert.AreEqual(123, customer.Id);
            Assert.AreEqual("MockCustomer 123", customer.Name);
        }

        private Customer CreateMockCustomer(int id, string name)
        {
            var customer = new Customer { Id = id, Name = name };
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;
        }
    }
}
