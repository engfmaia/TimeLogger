using System.Collections.Generic;

namespace Timelogger.Models
{
    public sealed class CustomerDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ICollection<ProjectDto> Projects { get; set; }
    }
}