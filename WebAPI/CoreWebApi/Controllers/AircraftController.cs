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
        private readonly IAircraftService _aircraftService;

        public AircraftController(IAircraftService  aircraftService)
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


        [HttpGet("GetByID/{Id}")]
        public JsonResult GetByID(int id)
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

        public JsonResult Create(AircraftDM AircraftDM_Obj)
        {
            try
            {
                var result = _aircraftService.AddAsync(AircraftDM_Obj);
                if (result != null)
                {
                    return Json(new { success = true, message = "Aircraft Added  Sucessfully  !", status_code = 200, result });
                }
                else
                {
                    return Json(new { success = true, message = "Aircraft  Adding Failed!", all_Aircrafts = result });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while recording the Aircraft." });
            }
        }
        [HttpPut]
        public JsonResult Update(AircraftDM AircraftDM_Obj)
        {
            try
            {
                var result = _aircraftService.UpdateAsync(AircraftDM_Obj);
                if (result != null)
                {
                    return Json(new { success = true, message = "Aircraft  Sucessfully Updated!", status_code = 200, result });
                }
                else
                {
                    return Json(new { success = true, message = "Aircraft  Updating Failed!", all_Aircrafts = result });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while updating the Aircraft ." });
            }
        }
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            try
            {
                var result = _aircraftService.DeleteAsync(id);
                if (result != null)
                {
                    return Json(new { success = true, message = "Aircraft  Record Removed!", status_code = 200, result });
                }
                else
                {
                    return Json(new { success = true, message = "Aircraft  Record Removing Failed!", all_Aircrafts = result });
                }
            }
            catch (Exception)
            {
                return Json(new { success = false, status_code = 400, message = "An error occured while Removing the Aircraft." });
            }
        }


        [HttpGet("GetByMake/{make}")]
        public JsonResult GetByMake(string make)
        {
            try
            {
                if (make == null)
                {
                    return Json(new { success = true, message = "No Aircrafts found!" });
                }

                var data = _aircraftService.GetbyMakeAsync(make);
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
        [HttpGet("GetByModel/{model}")]
        public JsonResult GetByModel(string model)
        {
            try
            {
                if (model == null)
                {
                    return Json(new { success = true, message = "No Aircrafts found!" });
                }

                var data = _aircraftService.GetbyModelAsync(model);
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

        [HttpGet("GetByRegistration/{registration}")]
        public JsonResult GetByRegistration(string registration)
        {
            try
            {
                if (registration == null)
                {
                    return Json(new { success = true, message = "No Aircrafts found!" });
                }

                var data = _aircraftService.GetbyRegistrationAsync(registration);
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
