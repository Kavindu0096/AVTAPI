using InfrastructureLayer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using RepositoryLayer;
using RepositoryLayer.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace ServiceLayer
{
    public class AircraftSightingService : IAircraftSightingService
    {
        private readonly IAircraftSightingRepo _iRepo;
        private readonly IHostingEnvironment webHostEnvironment;
        private readonly string uploadsFolder = "Resources";
        public AircraftSightingService(IAircraftSightingRepo iRepo)
        {
            _iRepo = iRepo;
        }
        public async Task<bool> AddAsync(AircraftSightingDM dataDM)
        {
            string UIamgePath = UploadedFile(dataDM);
            var obj = new TblAircraftSighting();
            obj.Make = dataDM.Make;
            obj.Model = dataDM.Model;
            obj.Registration = dataDM.Registration;
            obj.Location = dataDM.Location;
            obj.AircraftId = dataDM.AircraftId;
            obj.SightingAt = dataDM.SightingAt;
            obj.CreatedBy = dataDM.CreatedBy;
            obj.Uimage = UIamgePath;

            var results = await _iRepo.Add(obj);
            return results;

        }
        private string UploadedFile(AircraftSightingDM model)
        {
            string UIamgePath = null;

            if (model.UImage != null && model.UImageName!=null)
            {
                byte[] imageBytes = Convert.FromBase64String(model.UImage);
                MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
                //  string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Resources");
                //string uploadsFolder = HttpContext.Current.Server.MapPath("/image");

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model.UImageName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                var fileStream = new FileStream(filePath, FileMode.Create);
                fileStream.Write(imageBytes);
                UIamgePath = filePath;
            }
            return UIamgePath;
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
                DeletedAt = data.DeletedAt,
                UImage = RetriveFile(data.Uimage)
            }).ToList();
            return AircraftSighting_List;
        }

        private string RetriveFile(String UImagePath)
        {
            string UIamge = null;
            try
            {
                if (UImagePath != null)
                {

                   // string filePath = Path.Combine(uploadsFolder, UImagePath);
                    Image image = Image.FromFile(UImagePath);
                    MemoryStream ms = new MemoryStream();
                    image.Save(ms, image.RawFormat);
                    byte[] imageBytes = ms.ToArray();
                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    UIamge = base64String;

                }
            }
            catch (Exception ex)
            {

            }
            return UIamge;
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
            TblAircraftSightingObj.SightingAt = data.SightingAt;
            TblAircraftSightingObj.CreatedBy = data.CreatedBy;
            TblAircraftSightingObj.ModifiedAt = data.ModifiedAt;
            TblAircraftSightingObj.ModifiedBy = data.ModifiedBy;
            TblAircraftSightingObj.DeletedAt = data.DeletedAt;
            TblAircraftSightingObj.UImage = RetriveFile(data.Uimage);
            return TblAircraftSightingObj;
        }

        public async Task<bool> UpdateAsync(AircraftSightingDM dataDM)
        {
            string UIamgePath = UploadedFile(dataDM);
            var obj = new TblAircraftSighting();
            obj.Id = dataDM.Id;
            obj.Make = dataDM.Make;
            obj.Model = dataDM.Model;
            obj.Registration = dataDM.Registration;
            obj.Location = dataDM.Location;
            obj.AircraftId = dataDM.AircraftId;
            obj.SightingAt = DateTime.UtcNow;
            obj.CreatedBy = dataDM.CreatedBy;
            obj.Uimage = UIamgePath;

            var results = await _iRepo.Update(obj);
            return results;
        }
    }
}
