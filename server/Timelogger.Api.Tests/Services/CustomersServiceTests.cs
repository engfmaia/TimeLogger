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

        private const string MockCustomerName = "Mock Customer Name";
        private const int MockCustomerId = 123;

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
        public void QueryingCustomerWithValidButNoExistingId_Should_ThrowNullReferenceException()
        {
            Assert.That(() => _customersService.GetCustomer(5),
                Throws.Exception
                  .TypeOf<NullReferenceException>());
        }

        [Test]
        public void QueryingProjectWithExistingId_Should_ReturnCorrectlyMappedDto()
        {
            CreateMockCustomer(MockCustomerId, MockCustomerName);

            var customer = _customersService.GetCustomer(MockCustomerId);
            Assert.AreEqual(MockCustomerId, customer.Id);
            Assert.AreEqual(MockCustomerName, customer.Name);
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
