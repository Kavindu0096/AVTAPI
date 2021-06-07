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
    [Route("api/AircraftSighting")]
    [ApiController]
    public class AircraftSightingController : Controller
    {
        private readonly IAircraftSightingService _aircraftSightingService;

        public AircraftSightingController(IAircraftSightingService aircraftSightingService)
        {
            _aircraftSightingService = aircraftSightingService;
        }

        
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                var data = _aircraftSightingService.GetAllAsync();
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
        [HttpGet("GetByID/{Id}")]
        public JsonResult GetByID(long id)
        {
            try
            {
                if (id == null)
                {
                    return Json(new { success = true, message = "No Aircraft Sighting found!" });
                }

                var data = _aircraftSightingService.GetByIdAsync(id);
                if (data != null)
                {
                    return Json(new { success = true, status_code = 200, data });
                }
                else
                {
                    return Json(new { success = true, message = "No Aircraft Sighting found!", all_Aircrafts = data });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while retrieving the Aircraft Sighting." });
            }

        }
       
        [HttpPost]

        public JsonResult Create(AircraftSightingDM AircraftSighting_Obj)
        {
            try
            {
                var result = _aircraftSightingService.AddAsync(AircraftSighting_Obj);
                if (result != null)
                {
                    return Json(new { success = true, message = "Aircraft Sighting Sucessfully Recorded !", status_code = 200, result });
                }
                else
                {
                    return Json(new { success = true, message = "Aircraft Sighting Adding Failed!", all_Aircrafts = result });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while recording the Aircraft Sightings." });
            }
        }
        [HttpPut]
        public JsonResult Update(AircraftSightingDM AircraftSighting_Obj)
        {
            try
            {
                var result = _aircraftSightingService.UpdateAsync(AircraftSighting_Obj);
                if (result != null)
                {
                    return Json(new { success = true, message = "Aircraft Sighting Sucessfully Updated!", status_code = 200, result });
                }
                else
                {
                    return Json(new { success = true, message = "Aircraft Sightings Updating Failed!", all_Aircrafts = result });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while updating the Aircraft Sightings." });
            }
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            try
            {
                var result = _aircraftSightingService.DeleteAsync(id);
                if (result != null)
                {
                    return Json(new { success = true, message = "Aircraft Sighting Record Removed!", status_code = 200, result });
                }
                else
                {
                    return Json(new { success = true, message = "Aircraft Sighting Record Removing Failed!", all_Aircrafts = result });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while Removing the Aircraft Sightings." });
            }
        }
    }
}
