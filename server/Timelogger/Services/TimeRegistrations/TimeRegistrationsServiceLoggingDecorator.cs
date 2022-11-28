using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Timelogger.Models;

namespace Timelogger.Services.TimeRegistrations
{
    public class TimeRegistrationsServiceLoggingDecorator : ITimeRegistrationsService
    {
        private readonly ITimeRegistrationsService _timeRegistrationsService;
        private readonly ILogger<TimeRegistrationsServiceLoggingDecorator> _logger;

        public TimeRegistrationsServiceLoggingDecorator(ITimeRegistrationsService timeRegistrationsService, ILogger<TimeRegistrationsServiceLoggingDecorator> logger)
        {
            _timeRegistrationsService = timeRegistrationsService;
            _logger = logger;
        }

        public TimeRegistrationDto CreateTimeRegistration(int projectId, decimal hours, DateTime date)
        {
            _logger.LogDebug($"Time Registrations creation started: Project Id {projectId} Hours {hours} Date {date}", DateTime.UtcNow.ToLongTimeString());

            try
            {
                var timeRegistration = _timeRegistrationsService.CreateTimeRegistration(projectId, hours, date);
                _logger.LogDebug($"Time Registrations creation started: Project Id {projectId} Hours {hours} Date {date}", DateTime.UtcNow.ToLongTimeString());
                return timeRegistration;
            }
            catch (Exception exception)
            {
                _logger.LogDebug($"Time Registrations creation started: Project Id {projectId} Hours {hours} Date {date} and throwed exception {exception.GetType()} - {exception.Message}", DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }

        public ICollection<TimeRegistrationDto> GetTimeRegistrations(int projectId)
        {
            _logger.LogDebug($"Time Registrations retrieval started: Project Id {projectId}", DateTime.UtcNow.ToLongTimeString());

            try
            {
                var timeRegistrations = _timeRegistrationsService.GetTimeRegistrations(projectId);
                _logger.LogDebug($"Time Registrations retrieval started: Project Id {projectId}", DateTime.UtcNow.ToLongTimeString());
                return timeRegistrations;
            }
            catch (Exception exception)
            {
                _logger.LogDebug($"Time Registrations retrieval started: Project Id {projectId} and throwed exception {exception.GetType()} - {exception.Message}", DateTime.UtcNow.ToLongTimeString());
                throw;
            }
        }
    }
}