using InfrastructureLayer;
using Microsoft.AspNetCore.Hosting;
using RepositoryLayer;
using RepositoryLayer.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AircraftSightingService : IService<AircraftSightingDM>
    {
        private readonly IRepo<TblAircraftSighting> _iRepo;
        private readonly IHostingEnvironment webHostEnvironment;
        public AircraftSightingService(IRepo<TblAircraftSighting> iRepo)
        {
            _iRepo = iRepo;
        }
        public async Task<bool> AddAsync(AircraftSightingDM dataDM)
        {
            string uniqueFileName = UploadedFile(dataDM);
            var obj = new TblAircraftSighting();
            obj.Make = dataDM.Make;
            obj.Model = dataDM.Model;
            obj.Registration = dataDM.Registration;
            obj.Location = dataDM.Location;
            obj.AircraftId = dataDM.AircraftId;
            obj.SightingAt = dataDM.SightingAt;
            obj.CreatedBy = dataDM.CreatedBy;
            obj.Uimage = uniqueFileName;

            var results = await _iRepo.Add(obj);
            return results;

        }
        private string UploadedFile(AircraftSightingDM model)
        {
            string uniqueFileName = null;

            if (model.UImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.UImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var results = await _iRepo.Delete(id);
            return results;
        }

        public async Task<List<AircraftSightingDM>> GetAllAsync()
        {
            List<TblAircraftSighting> datatList = await _iRepo.GetAll();

            List<AircraftSightingDM> AircraftSighting_List = new List<AircraftSightingDM>();
            AircraftSighting_List = datatList.Select(data => new AircraftSightingDM()
            {
                Id = data.Id,
                Make = data.Make,
                Model = data.Model,
                Registration = data.Registration,
                AircraftId = data.AircraftId,
                Location = data.Location,
                CreatedBy = data.CreatedBy,
                SightingAt = data.SightingAt,
                ModifiedAt = data.ModifiedAt,
                ModifiedBy = data.ModifiedBy,
                DeletedAt = data.DeletedAt
            }).ToList();
            return AircraftSighting_List;
        }

        public async Task<AircraftSightingDM> GetByIdAsync(long id)
        {
            TblAircraftSighting data = await _iRepo.GetbyID(id);
            AircraftSightingDM TblAircraftSightingObj = new AircraftSightingDM();

            var obj = new TblAircraftSighting();
            TblAircraftSightingObj.Id = data.Id;
            TblAircraftSightingObj.Make = data.Make;
            TblAircraftSightingObj.Model = data.Model;
            TblAircraftSightingObj.Registration = data.Registration;
            TblAircraftSightingObj.Location = data.Location;
            TblAircraftSightingObj.AircraftId = data.AircraftId;
            TblAircraftSightingObj.SightingAt = DateTime.UtcNow;
            TblAircraftSightingObj.CreatedBy = data.CreatedBy;
            TblAircraftSightingObj.ModifiedAt = data.ModifiedAt;
            TblAircraftSightingObj.ModifiedBy = data.ModifiedBy;
            TblAircraftSightingObj.DeletedAt = data.DeletedAt;

            return TblAircraftSightingObj;
        }

        public async Task<bool> UpdateAsync(AircraftSightingDM dataDM)
        {
            var obj = new TblAircraftSighting();
            obj.Id = dataDM.Id;
            obj.Make = dataDM.Make;
            obj.Model = dataDM.Model;
            obj.Registration = dataDM.Registration;
            obj.Location = dataDM.Location;
            obj.AircraftId = dataDM.AircraftId;
            obj.SightingAt = DateTime.UtcNow;
            obj.CreatedBy = dataDM.CreatedBy;


            var results = await _iRepo.Update(obj);
            return results;
        }
    }
}
