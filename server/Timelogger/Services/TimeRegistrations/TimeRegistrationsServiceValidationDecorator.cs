using System;
using System.Collections.Generic;
using Timelogger.Models;

namespace Timelogger.Services.TimeRegistrations
{
    public class TimeRegistrationsServiceValidationDecorator : ITimeRegistrationsService
    {
        private readonly ITimeRegistrationsService _timeRegistrationsService;

        public TimeRegistrationsServiceValidationDecorator(ITimeRegistrationsService timeRegistrationsService)
        {
            _timeRegistrationsService = timeRegistrationsService;
        }

        public TimeRegistrationDto CreateTimeRegistration(int projectId, decimal hours, DateTime date)
        {
            if (projectId < 0)
            {
                throw new ArgumentOutOfRangeException("Project Id must be higher than zero");
            }

            if (hours < 0.5m)
            {
                throw new ArgumentOutOfRangeException("Hours must be higher than 0.5h - 30 minutes");
            }

            if (date > DateTime.UtcNow)
            {
                throw new ArgumentOutOfRangeException("Time Registration date must be a past date");
            }

            return _timeRegistrationsService.CreateTimeRegistration(projectId, hours, date);
        }

        public ICollection<TimeRegistrationDto> GetTimeRegistrations(int projectId)
        {
            if (projectId < 0)
            {
                throw new ArgumentOutOfRangeException("Project Id must be higher than zero");
            }

            return _timeRegistrationsService.GetTimeRegistrations(projectId);
        }
    }
}