using System;

namespace Timelogger.Entities
{
    public class TimeRegistration
    {
        public int Id { get; set; }

        public decimal Hours { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreationDate { get; set; }

        public Project Project { get; set; }
    }
}
