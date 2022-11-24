using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Timelogger.Models;

namespace Timelogger.Services.Projects
{
    public class ProjectsServiceLoggingDecorator : IProjectsService
    {
        private readonly IProjectsService _projectsService;
        private readonly ILogger<ProjectsServiceLoggingDecorator> _logger;

        public ProjectsServiceLoggingDecorator(IProjectsService projectsService, ILogger<ProjectsServiceLoggingDecorator> logger)
        {
            this._projectsService = projectsService;
            this._logger = logger;
        }

        public ProjectDto CreateProject(int customerId, string name, DateTime deadline)
        {
            _logger.LogDebug("Project creation started", DateTime.UtcNow.ToLongTimeString());

            var project = _projectsService.CreateProject(customerId, name, deadline);

            _logger.LogDebug("Project creation finished", DateTime.UtcNow.ToLongTimeString());

            return project;
        }

        public ProjectDto GetProject(int id)
        {
            _logger.LogDebug("Project retrieval", DateTime.UtcNow.ToLongTimeString());

            return _projectsService.GetProject(id);
        }

        public ICollection<ProjectDto> GetProjects(bool orderAsceding)
        {
            _logger.LogDebug("Projects retrieval", DateTime.UtcNow.ToLongTimeString());

            return _projectsService.GetProjects(orderAsceding);
        }
    }
}
