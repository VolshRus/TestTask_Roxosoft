using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Reflection;

using WebApp._Internal.Repositories;
using WebApp.Services;
using WebApp.Interfaces;
using Microsoft.Extensions.Logging;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDbContext<OrdersRepository>(DbOptions);

            services.AddScoped<IOrdersService, OrdersService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();
        }

        private Action<DbContextOptionsBuilder> DbOptions => builder =>
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("DefaultConnection");
                var warnEvents = RelationalEventId.QueryClientEvaluationWarning;
                builder
                     .UseNpgsql(connectionString)
                     .ConfigureWarnings(warn => warn.Throw(warnEvents));
            }
            catch(Exception e)
            {
                _logger.LogCritical(e, "Cannot find db connection string.");
            }
        };

        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
    }
}
