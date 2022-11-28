using System;
using System.Collections.Generic;

namespace Timelogger.Models
{
    public sealed class ProjectDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Deadline { get; set; }

        public CustomerDto Customer { get; set; }

        public bool Completed => Deadline < DateTime.UtcNow;

        public ICollection<TimeRegistrationDto> TimeRegistrations { get; set; }
    }
}
