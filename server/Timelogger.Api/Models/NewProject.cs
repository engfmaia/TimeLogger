using System;

namespace Timelogger.Api.Models
{
    public class NewProject
    {
        public string Name { get; set; }

        public int CustomerId { get; set; }

        public DateTime Deadline { get; set; }
    }
}
