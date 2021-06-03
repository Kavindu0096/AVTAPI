using InfrastructureLayer;
using Microsoft.Extensions.DependencyInjection;
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
            IServiceCollection services = new ServiceCollection();
            services.AddScoped<IRepo<TblAircraft>, AircraftRepo>();
            services.AddScoped<IService<AircraftDM>, AircraftService>();

            services.AddScoped<IRepo<TblAircraftSighting>, AircraftSightingRepo>();
            services.AddScoped<IService<AircraftSightingDM>, AircraftSightingService>();
            services.AddDbContext<AVTContext>();
            return services.BuildServiceProvider();
        }
    }
}
