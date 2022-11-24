using System;
using System.Collections.Generic;
using Timelogger.Models;

namespace Timelogger.Services.Projects
{
    public interface IProjectsService
    {
        public ProjectDto GetProject(int id);

        public ICollection<ProjectDto> GetProjects(bool orderAsceding = true);

        public ProjectDto CreateProject(int customerId, string name, DateTime deadline);
    }
}
