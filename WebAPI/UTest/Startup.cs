using InfrastructureLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using NUnit.Framework;
using RepositoryLayer;
using RepositoryLayer.DB;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace UTest
{
    [SetUpFixture]
    public class Startup
    {
        internal static IServiceProvider ServiceProvider { get; set; }
 
        public IConfiguration Configuration { get; set; }


        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            
            ServiceProvider = ContainerBuilder();
            
        }
        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {

        }
        public IServiceProvider ContainerBuilder()
        {
          
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();

            string conStr = this.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AVTContext>(options => options.UseSqlServer(conStr));
            services.AddScoped<IAircraftRepo, AircraftRepo>();
            services.AddScoped<IAircraftService, AircraftService>();

            services.AddScoped<IAircraftSightingRepo, AircraftSightingRepo>();
            services.AddScoped<IAircraftSightingService, AircraftSightingService>();
            services.AddDbContext<AVTContext>();

            
            return services.BuildServiceProvider();
        }
    }
}
