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
            _projectsService = projectsService;
            _logger = logger;
        }

        public ProjectDto CreateProject(int customerId, string name, DateTime deadline)
        {
            _logger.LogDebug($"Project creation started: Customer Id {customerId} Project Name {name} Deadline {deadline}", DateTime.UtcNow.ToLongTimeString());

            try
            {
                var project = _projectsService.CreateProject(customerId, name, deadline);
                _logger.LogDebug($"Project creation finished: Customer Id {customerId} Project Name {name} Deadline {deadline}", DateTime.UtcNow.ToLongTimeString());
                return project;
            }
            catch (Exception exception)
            {
                _logger.LogDebug($"Project creation finished: Customer Id {customerId} Project Name {name} Deadline {deadline} and throwed exception {exception.GetType()} - {exception.Message}", DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }

        public ProjectDto GetProject(int id)
        {
            _logger.LogDebug($"Project retrieval started: Project Id {id}", DateTime.UtcNow.ToLongTimeString());

            try
            {
                var project = _projectsService.GetProject(id);
                _logger.LogDebug($"Project retrieval finished: Project Id {id}", DateTime.UtcNow.ToLongTimeString());
                return project;
            }
            catch (Exception exception)
            {
                _logger.LogDebug($"Project retrieval finished: Project Id {id} and throwed exception {exception.GetType()} - {exception.Message}", DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }

        public ICollection<ProjectDto> GetProjects(bool orderAsceding)
        {
            _logger.LogDebug("Projects retrieval started", DateTime.UtcNow.ToLongTimeString());

            try
            {
                var projects = _projectsService.GetProjects(orderAsceding);
                _logger.LogDebug("Projects retrieval finished", DateTime.UtcNow.ToLongTimeString());
                return projects;
            }
            catch (Exception exception)
            {
                _logger.LogDebug($"Projects retrieval finished and throwed exception {exception.GetType()} - {exception.Message}", DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }
    }
}