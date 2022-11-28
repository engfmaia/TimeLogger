using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;
using Timelogger.Models;

namespace Timelogger.Services.Projects
{
    public class ProjectsService : IProjectsService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public ProjectsService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProjectDto CreateProject(int customerId, string name, DateTime deadline)
        {
            var project = _context.Projects.Add(new Project
            {
                Name = name,
                CreationDate = DateTime.UtcNow,
                Deadline = deadline,
                Customer = GetCustomerById(customerId)
            });

            _context.SaveChanges();

            return _mapper.Map<ProjectDto>(project.Entity);
        }

        public ProjectDto GetProject(int id)
        {
            var project = _context.Projects.Find(id);

            if (project == null)
                throw new NullReferenceException("Project does not exist");

            return _mapper.Map<ProjectDto>(project);
        }

        public ICollection<ProjectDto> GetProjects(bool orderAsceding)
        {
            return orderAsceding
                        ? _context.Projects.OrderBy(project => project.Deadline).Select(project => _mapper.Map<ProjectDto>(project)).ToList()
                        : _context.Projects.OrderByDescending(project => project.Deadline).Select(project => _mapper.Map<ProjectDto>(project)).ToList();
        }

        private Customer GetCustomerById(int customerId)
        {
            var customer = _context.Customers.Find(customerId);

            if (customer == null)
                throw new NullReferenceException("Customer does not exist");

            return customer;
        }
    }
}