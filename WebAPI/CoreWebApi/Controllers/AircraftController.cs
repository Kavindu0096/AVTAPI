using InfrastructureLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AircraftController : Controller
    {
        private readonly IService<AircraftDM> _aircraftService;

        public AircraftController(IService<AircraftDM> aircraftService)
        {
            _aircraftService = aircraftService;
        }
        // GET: Users
        public async Task<IActionResult> Index()
        {
            var data = await _aircraftService.GetAllAsync();
            if (data!=null)
            {
                return Json(new { success = true, status_code = 200, data });
            }
            else
            {
                return Json(new { success = true, message = "No Aircrafts found!", all_Aircrafts = data });
            }
            
        }
    }
}
