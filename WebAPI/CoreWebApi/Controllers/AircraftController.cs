using InfrastructureLayer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/Aircraft")]
    [ApiController]
    public class AircraftController : Controller
    {
        private readonly IService<AircraftDM> _aircraftService;

        public AircraftController(IService<AircraftDM> aircraftService)
        {
            _aircraftService = aircraftService;
        }
        // GET: Users
        
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                var data = _aircraftService.GetAllAsync();
                if (data != null)
                {
                    return Json(new { success = true, status_code = 200, data });
                }
                else
                {
                    return Json(new { success = true, message = "No Aircrafts found!", all_Aircrafts = data });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while retrieving the Aircrafts." });
            }
        }
        [HttpGet("GetById/{Id}")]
        public JsonResult GetByID(long id)
        {
            try
            {
                if (id == null)
                {
                    return Json(new { success = true, message = "No Aircrafts found!" });
                }

                var data = _aircraftService.GetByIdAsync(id);
                if (data != null)
                {
                    return Json(new { success = true, status_code = 200, data });
                }
                else
                {
                    return Json(new { success = true, message = "No Aircrafts found!", all_Aircrafts = data });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while retrieving the Aircrafts." });
            }

        }
    }
}
