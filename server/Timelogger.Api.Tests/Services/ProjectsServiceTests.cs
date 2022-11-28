using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using Timelogger.Entities;
using Timelogger.Mappers;
using Timelogger.Services.Projects;

namespace Timelogger.Api.Tests
{
    public class ProjectsServiceTests
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        private readonly IProjectsService _projectsService;

        private const string MockCustomerName = "Mock Customer";
        private const int MockCustomerId = 123;
        private const string MockProjectOneName = "Mock Project One";
        private const int MockProjectOneId = 111;
        private const string MockProjectTwoName = "Mock Project Two";
        private const int MockProjectTwoId = 222;

        public ProjectsServiceTests()
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

            _projectsService = new ProjectsService(_context, _mapper);
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Projects.RemoveRange(_context.Projects);
        }

        [Test]
        public void QueryingProjectWithNoExistingId_Should_ThrowNullReferenceException()
        {
            CreateMockProject(MockProjectOneId, MockProjectOneName);
            CreateMockProject(MockProjectTwoId, MockProjectTwoName);

            Assert.That(() => _projectsService.GetProject(9999),
                Throws.Exception
                  .TypeOf<NullReferenceException>());
        }

        [Test]
        public void QueryingProjectWithExistingId_Should_ReturnCorrectlyMappedDto()
        {
            CreateMockProject(MockProjectOneId, MockProjectOneName);
            CreateMockProject(MockProjectTwoId, MockProjectTwoName);

            var project = _projectsService.GetProject(MockProjectTwoId);
            Assert.AreEqual(MockProjectTwoId, project.Id);
            Assert.AreEqual(MockProjectTwoName, project.Name);
        }

        [Test]
        public void CreatingProjectWithNonExistingCustomer_Should_ThrowNullReferenceException()
        {
            Assert.That(() => _projectsService.CreateProject(1, MockProjectOneName, DateTime.UtcNow),
                Throws.Exception
                  .TypeOf<NullReferenceException>());
        }

        [Test]
        public void CreatingProjectWithValidName_Should_ReturnCorrectlyCreatedAndMappedDto()
        {
            CreateMockCustomer(MockCustomerId, MockCustomerName);
            var project = _projectsService.CreateProject(MockCustomerId, MockProjectOneName, DateTime.UtcNow);

            Assert.AreEqual(true, project.Id > 0);
            Assert.AreEqual(MockProjectOneName, project.Name);
        }

        private void CreateMockProject(int id, string name)
        {
            _context.Projects.Add(new Project { Id = id, Name = name });
            _context.SaveChanges();
        }

        private void CreateMockCustomer(int id, string name)
        {
            _context.Customers.Add(new Customer { Id = id, Name = name });
            _context.SaveChanges();
        }
    }
}
