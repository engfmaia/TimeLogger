using Microsoft.AspNetCore.Mvc;
using System;
using Timelogger.Api.Models;
using Timelogger.Services.TimeRegistrations;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    public class TimeRegistrationsController : Controller
    {
        private readonly ITimeRegistrationsService _timeRegistrationsService;

        public TimeRegistrationsController(ITimeRegistrationsService timeRegistrationsService)
        {
            _timeRegistrationsService = timeRegistrationsService;
        }

        [HttpGet]
        [Route("{projectId}")]
        public IActionResult Get(int projectId)
        {
            return Ok(_timeRegistrationsService.GetTimeRegistrations(projectId));
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewTimeRegistration newTimeRegistration)
        {
            if (newTimeRegistration.Hours < 0.5m)
            {
                throw new ArgumentOutOfRangeException("Time registrations should be for 30 minutes or more");
            }

            return Ok(_timeRegistrationsService.CreateTimeRegistration(newTimeRegistration.ProjectId, newTimeRegistration.Hours, newTimeRegistration.Date));
        }
    }
}