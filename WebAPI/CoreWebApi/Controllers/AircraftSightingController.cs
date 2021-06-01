using InfrastructureLayer;
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
    [Route("api/AircraftSighting")]
    [ApiController]
    public class AircraftSightingController : Controller
    {
        private readonly IService<AircraftSightingDM> _aircraftService;

        public AircraftSightingController(IService<AircraftSightingDM> aircraftService)
        {
            _aircraftService = aircraftService;
        }


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
                    return Json(new { success = true, message = "No Aircraft Sightings found!", all_Aircrafts = data });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while retrieving the Aircraft Sightings." });
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
        [HttpPost]
        public JsonResult Create(AircraftSightingDM AircraftSighting_Obj)
        {
            try
            {
                var result = _aircraftService.AddAsync(AircraftSighting_Obj);
                if (result != null)
                {
                    return Json(new { success = true, status_code = 200, result });
                }
                else
                {
                    return Json(new { success = true, message = "No Aircraft Sightings found!", all_Aircrafts = result });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while recording the Aircraft Sightings." });
            }
        }
    }
}
