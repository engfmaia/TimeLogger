using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;
using Timelogger.Models;

namespace Timelogger.Services.TimeRegistrations
{
    public class TimeRegistrationsService : ITimeRegistrationsService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public TimeRegistrationsService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TimeRegistrationDto CreateTimeRegistration(int projectId, decimal hours, DateTime date)
        {
            var project = GetProjectById(projectId);

            var timeRegistration = _context.TimeRegistrations.Add(new TimeRegistration
            {
                Hours = hours,
                Project = project,
                CreationDate = DateTime.UtcNow,
                Date = date
            });

            _context.SaveChanges();

            return _mapper.Map<TimeRegistrationDto>(timeRegistration.Entity);
        }

        public ICollection<TimeRegistrationDto> GetTimeRegistrations(int projectId)
        {
            var project = GetProjectById(projectId);

            return _context
                    .TimeRegistrations
                    .Where(timeRegistration => timeRegistration.Project.Id == projectId)
                    .OrderByDescending(timeRegistration => timeRegistration.Date)
                    .Select(customer => _mapper.Map<TimeRegistrationDto>(customer))
                    .ToList();
        }

        private Project GetProjectById(int projectId)
        {
            var project = _context.Projects.Find(projectId);

            if (project == null)
                throw new NullReferenceException("Project does not exist");

            return project;
        }
    }
}