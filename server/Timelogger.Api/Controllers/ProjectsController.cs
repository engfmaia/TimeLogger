using Microsoft.AspNetCore.Mvc;
using Timelogger.Api.Models;
using Timelogger.Services.Projects;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : Controller
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_projectsService.GetProject(id));
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll(bool orderAsceding = true)
        {
            return Ok(_projectsService.GetProjects(orderAsceding));
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewProject newProject)
        {
            return Ok(_projectsService.CreateProject(newProject.CustomerId, newProject.Name, newProject.Deadline));
        }
    }
}
