using System;
using System.Collections.Generic;
using Timelogger.Models;

namespace Timelogger.Services.TimeRegistrations
{
    public interface ITimeRegistrationsService
    {
        public ICollection<TimeRegistrationDto> GetTimeRegistrations(int projectId);

        public TimeRegistrationDto CreateTimeRegistration(int projectId, decimal hours, DateTime date);
    }
}