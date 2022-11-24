using System;

namespace Timelogger.Api.Models
{
    public class NewTimeRegistration
    {
        public int ProjectId { get; set; }

        public decimal Hours { get; set; }

        public DateTime Date { get; set; }
    }
}
