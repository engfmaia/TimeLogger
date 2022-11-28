using System;
using System.Collections.Generic;
using Timelogger.Models;

namespace Timelogger.Services.Projects
{
    public class ProjectsServiceValidationDecorator : IProjectsService
    {
        private readonly IProjectsService _projectsService;

        public ProjectsServiceValidationDecorator(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        public ProjectDto CreateProject(int customerId, string name, DateTime deadline)
        {
            if (customerId < 0)
            {
                throw new ArgumentOutOfRangeException("Customer Id must be higher than zero");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Project Name value must not be null or empty");
            }

            if (deadline <= DateTime.UtcNow)
            {
                throw new ArgumentNullException("Project deadline must be a future date");
            }

            var project = _projectsService.CreateProject(customerId, name, deadline);

            return project;
        }

        public ProjectDto GetProject(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Customer Id must be higher than zero");
            }

            return _projectsService.GetProject(id);
        }

        public ICollection<ProjectDto> GetProjects(bool orderAsceding)
        {
            return _projectsService.GetProjects(orderAsceding);
        }
    }
}
