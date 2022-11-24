using AutoMapper;
using FileContextCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Timelogger.Entities;
using Timelogger.Mappers;
using Timelogger.Services.Customers;
using Timelogger.Services.Projects;
using Timelogger.Services.TimeRegistrations;

namespace Timelogger.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        public IConfigurationRoot Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            _environment = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApiContext>(options => options.UseFileContextDatabase(
                databaseName: "MockFileDatabase"
            ));

            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            //Services
            services.AddScoped<IProjectsService, ProjectsService>();
            services.Decorate<IProjectsService, ProjectsServiceLoggingDecorator>();
            
            services.AddScoped<ITimeRegistrationsService, TimeRegistrationsService>();
            
            services.AddScoped<ICustomersService, CustomersService>();
            services.Decorate<ICustomersService, CustomersServiceLoggingDecorator>();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc(options => options.EnableEndpointRouting = false);

            if (_environment.IsDevelopment())
            {
                services.AddCors();
            }
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(builder => builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials());
            }

            app.UseMvc();
        }
    }
}