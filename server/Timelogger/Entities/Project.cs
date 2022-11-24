using System;

namespace Timelogger.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime Deadline { get; set; }

        public Customer Customer { get; set; }
    }
}
