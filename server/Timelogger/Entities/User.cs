using System;
using System.Collections.Generic;

namespace Timelogger.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Project> Projects { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}
