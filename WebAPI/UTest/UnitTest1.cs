
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
        private IService<AircraftSightingDM> _aircraftSightingService;
        [SetUp]
        public void Setup()
        {
            var serviceProvider = Startup.ServiceProvider;
            if (serviceProvider != null)
            {
                //_aircraftSightingService = (IService<AircraftSightingDM>)serviceProvider.GetServices<AircraftSightingDM>();
                //_aircraftSightingService = (IService<AircraftSightingDM>)serviceProvider.GetService(typeof(AircraftSightingDM));
                _aircraftSightingService = serviceProvider.GetService<IService<AircraftSightingDM>>();
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
                AircraftId = 0,
                CreatedBy = 0
            };
            var actualResult = await _aircraftSightingService.AddAsync(AircraftSighting);
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public async Task aircraftSightingGetAllTest()
        {
          

            var actualResult =   _aircraftSightingService.GetAllAsync().IsCompletedSuccessfully;
            var expectedResult = true;
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}