using NUnit.Framework;
using System;
using Timelogger.Services.Customers;

namespace Timelogger.Api.Tests
{
    public class CustomersServiceValidationDecoratorTests
    {
        private readonly ICustomersService _customersServiceValidationDecorator;

        public CustomersServiceValidationDecoratorTests()
        {
            _customersServiceValidationDecorator = new CustomersServiceValidationDecorator(null);
        }

        [Test]
        public void CreatingNewCustomerPassingNullOrWhiteSpaceAsName_Should_ThrowArgumentNullException()
        {
            Assert.That(() => _customersServiceValidationDecorator.CreateCustomer(string.Empty),
                Throws.Exception
                  .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void QueryingCustomerWithIdLowerThanZero_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _customersServiceValidationDecorator.GetCustomer(-1),
                Throws.Exception
                  .TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
