using System;

namespace Timelogger.Models
{
    public class TimeRegistrationDto
    {
        public int Id { get; set; }

        public decimal Hours { get; set; }

        public DateTime Date { get; set; }

        public ProjectDto Project { get; set; }
    }
}
