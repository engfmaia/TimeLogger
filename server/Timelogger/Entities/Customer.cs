using System;
using System.Collections.Generic;

namespace Timelogger.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
