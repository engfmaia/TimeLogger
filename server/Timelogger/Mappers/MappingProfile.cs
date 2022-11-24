using AutoMapper;
using Timelogger.Entities;
using Timelogger.Models;

namespace Timelogger.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TimeRegistration, TimeRegistrationDto>();
            CreateMap<Customer, CustomerDto>().ForMember(d => d.Projects, opt => opt.MapFrom(src => src.Projects));

            CreateMap<Project, ProjectDto>().ForMember(d => d.Customer, opt => opt.MapFrom(src => src.Customer));
        }
    }
}
