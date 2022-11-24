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

        [Test]
        public void QueryingProjectWithIdLowerThanZero_Should_ThrowArgumentOutOfRangeException()
        {
            Assert.That(() => _projectsService.GetProject(-1),
                Throws.Exception
                  .TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void QueryingProjectWithNoExistingId_Should_ThrowNullReferenceException()
        {
            CreateMockProject(111, "MockProject 1");
            CreateMockProject(222, "MockProject 2");

            Assert.That(() => _projectsService.GetProject(9999),
                Throws.Exception
                  .TypeOf<NullReferenceException>());
        }

        [Test]
        public void QueryingProjectWithExistingId_Should_ReturnCorrectlyMappedDto()
        {
            CreateMockProject(12, "MockProject 12");
            CreateMockProject(23, "MockProject 23");

            var project = _projectsService.GetProject(12);
            Assert.AreEqual(12, project.Id);
            Assert.AreEqual("MockProject 12", project.Name);
        }

        [Test]
        public void CreatingProjectWithNonExistingCustomer_Should_ThrowNullReferenceException()
        {
            Assert.That(() => _projectsService.CreateProject(1, "This is a new project", DateTime.Now),
                Throws.Exception
                  .TypeOf<NullReferenceException>());
        }

        [Test]
        public void CreatingProjectWithValidName_Should_ReturnCorrectlyCreatedAndMappedDto()
        {
            CreateMockCustomer(1, "Test Customer");
            var project = _projectsService.CreateProject(1, "This is a new project", DateTime.Now);
            Assert.AreEqual(true, project.Id > 0);
            Assert.AreEqual("This is a new project", project.Name);
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
