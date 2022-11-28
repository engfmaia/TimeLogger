using NUnit.Framework;
using System;
using Timelogger.Services.TimeRegistrations;

namespace Timelogger.Api.Tests
{
    public class TimeRegistrationsServiceValidationDecoratorTests
    {
        private readonly ITimeRegistrationsService _timeRegistrationsService;

        public TimeRegistrationsServiceValidationDecoratorTests()
        {
            _timeRegistrationsService = new TimeRegistrationsServiceValidationDecorator(null);
        }

        [Test]
        public void CreatingTimeRegistrationPassingProjectIdLowerThanZero_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _timeRegistrationsService.CreateTimeRegistration(-1, 1m, DateTime.UtcNow),
                Throws.Exception
                  .TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CreatingTimeRegistrationPassingMHoursLowerThanThirtyMinutes_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _timeRegistrationsService.CreateTimeRegistration(1, 0.4m, DateTime.UtcNow),
                Throws.Exception
                  .TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CreatingTimeRegistrationPassingDateInTheFuture_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _timeRegistrationsService.CreateTimeRegistration(1, 1m, DateTime.UtcNow.AddDays(1)),
                Throws.Exception
                  .TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void QueryingTimeRegistrationsForProjectWithIdLowerThanZero_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _timeRegistrationsService.GetTimeRegistrations(-1),
                Throws.Exception
                  .TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
