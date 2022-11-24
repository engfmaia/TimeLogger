using Microsoft.EntityFrameworkCore;
using Timelogger.Entities;

namespace Timelogger
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public ApiContext()
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Project> Projects { get; set; }

        public DbSet<TimeRegistration> TimeRegistrations { get; set; }
    }
}
