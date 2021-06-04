
using InfrastructureLayer;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RepositoryLayer.DB;
using ServiceLayer;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace UTest
{
    public class Tests
    {
        private IAircraftSightingService _aircraftSightingService;
        private IAircraftService _aircraftService;
        [SetUp]
        public void Setup()
        {
            var serviceProvider = Startup.ServiceProvider;
            if (serviceProvider != null)
            {
                
                _aircraftSightingService = serviceProvider.GetService<IAircraftSightingService>();
                _aircraftService = serviceProvider.GetService<IAircraftService>();
            }
        }

        [Test]
        public async Task aircraftSightingAddTest()
        {
            var AircraftSighting = new AircraftSightingDM
            {
                Make = "Boeing",
                Model = "747",
                Registration = "G-RNAC",
                Location = "London Gatwick”",
                SightingAt = System.DateTime.UtcNow,
                AircraftId = 1,
                CreatedBy = 0
            };
            var actualResult = await _aircraftSightingService.AddAsync(AircraftSighting);
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public async Task aircraftAddTest()
        {
            var Aircraft = new AircraftDM
            {
                Make = "Boeing",
                Model = "747",
                Registration = "G-RNAC",
                CreatedBy = 0
            };
            var actualResult = await _aircraftService.AddAsync(Aircraft);
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult);
        }

    }
}