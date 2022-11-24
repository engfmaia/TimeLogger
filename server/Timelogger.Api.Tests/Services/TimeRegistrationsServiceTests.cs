using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using Timelogger.Entities;
using Timelogger.Mappers;
using Timelogger.Services.TimeRegistrations;

namespace Timelogger.Api.Tests
{
    public class TimeRegistrationsServiceTests
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        private readonly ITimeRegistrationsService _timeRegistrationsService;

        public TimeRegistrationsServiceTests()
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

            _timeRegistrationsService = new TimeRegistrationsService(_context, _mapper);
        }

        [Test]
        public void CreatingTimeRegistrationForNonExistingProject_Should_ThrowNullReferenceException()
        {
            Assert.That(() => _timeRegistrationsService.CreateTimeRegistration(1, 1m, DateTime.Now),
                Throws.Exception
                  .TypeOf<NullReferenceException>());
        }

        [Test]
        public void QueryingTimeRegistrationsForProjectWithExistingId_Should_ReturnCorrectlyMappedDto()
        {
            var project = CreateMockProject(12, 25, "MockProject 12");
            CreateMockTimeRegistration(project, 2, DateTime.Now);
            CreateMockTimeRegistration(project, 2, DateTime.Now);

            var timeRegistrationsOfProject = _timeRegistrationsService.GetTimeRegistrations(12);
            Assert.AreEqual(2, timeRegistrationsOfProject.Count);
        }

        private void CreateMockTimeRegistration(Project project, decimal hours, DateTime date)
        {
            _context.TimeRegistrations.Add(new TimeRegistration { Project = project, Hours = hours, Date = date });
            _context.SaveChanges();
        }

        private Project CreateMockProject(int id, int customerId, string name)
        {
            var project = new Project { Id = id, Name = name, Customer = new Customer { Id = customerId } };
            _context.Projects.Add(project);
            _context.SaveChanges();
            return project;
        }
    }
}
