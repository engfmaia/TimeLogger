using NUnit.Framework;
using System;
using Timelogger.Services.Projects;

namespace Timelogger.Api.Tests
{
    public class ProjectsServiceValidationDecoratorTests
    {
        private readonly IProjectsService _projectsService;

        public ProjectsServiceValidationDecoratorTests()
        {
            _projectsService = new ProjectsServiceValidationDecorator(null);
        }

        [Test]
        public void CreatingProjectPassingCustomerIdLowerThanZero_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _projectsService.CreateProject(-1, string.Empty, DateTime.UtcNow),
                Throws.Exception
                  .TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CreatingProjectPassingEmptyOrNullName_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _projectsService.CreateProject(1, string.Empty, DateTime.UtcNow),
                Throws.Exception
                  .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CreatingProjectPassingDateInThePast_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _projectsService.CreateProject(1, "Project Name", DateTime.UtcNow.AddDays(-1)),
                Throws.Exception
                  .TypeOf<ArgumentNullException>());
        }

        [Test]
        public void QueryingProjectWithIdLowerThanZero_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _projectsService.GetProject(-1),
                Throws.Exception
                  .TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
