using InfrastructureLayer;
using RepositoryLayer;
using RepositoryLayer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class AircraftService : IAircraftService
    {
        private readonly IAircraftRepo _iRepo;
        public AircraftService(IAircraftRepo iRepo)
        {
            _iRepo = iRepo;
        }

        public async Task<bool> AddAsync(AircraftDM dataDM)
        {

            var obj = new TblAircraft();
            obj.Make = dataDM.Make;
            obj.Model = dataDM.Model;
            obj.Registration = dataDM.Registration;
            obj.CreatedBy = dataDM.CreatedBy;
            obj.CreatedAt = DateTime.UtcNow;

            var results = await _iRepo.Add(obj);
            return results;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            var results = await _iRepo.Delete(id);
            return results;
        }

        public async Task<List<AircraftDM>> GetAllAsync()
        {

            List<TblAircraft> datatList = await _iRepo.GetAll();

            List<AircraftDM> AircraftList = new List<AircraftDM>();
            AircraftList = datatList.Select(data => new AircraftDM()
            {
                AircraftId = data.AircraftId,
                Make = data.Make,
                Model = data.Model,
                Registration = data.Registration,
                CreatedBy = data.CreatedBy,
                CreatedAt = data.CreatedAt,
                ModifiedAt = data.ModifiedAt,
                ModifiedBy = data.ModifiedBy,
                DeletedAt = data.DeletedAt
            }).ToList();
            return AircraftList;

        }

        public async Task<AircraftDM> GetByIdAsync(long id)
        {


            TblAircraft data = await _iRepo.GetbyID(id);
            AircraftDM AircrafObj = new AircraftDM();
            AircrafObj.AircraftId = data.AircraftId;
            AircrafObj.Make = data.Make;
            AircrafObj.Model = data.Model;
            AircrafObj.Registration = data.Registration;
            AircrafObj.CreatedBy = data.CreatedBy;
            AircrafObj.CreatedAt = data.CreatedAt;
            AircrafObj.ModifiedAt = data.ModifiedAt;
            AircrafObj.ModifiedBy = data.ModifiedBy;
            AircrafObj.DeletedAt = data.DeletedAt;

            return AircrafObj;

        }


        public async Task<List<AircraftDM>> GetbyMakeAsync(string Make)
        {


            List<TblAircraft> dataList = await _iRepo.GetbyMake(Make);
            List<AircraftDM> AircraftList = new List<AircraftDM>();
            AircraftList = dataList.Select(data => new AircraftDM()
            {
                AircraftId = data.AircraftId,
                Make = data.Make,
                Model = data.Model,
                Registration = data.Registration,
                CreatedBy = data.CreatedBy,
                CreatedAt = data.CreatedAt,
                ModifiedAt = data.ModifiedAt,
                ModifiedBy = data.ModifiedBy,
                DeletedAt = data.DeletedAt
            }).ToList();
            return AircraftList;

        }


        public async Task<List<AircraftDM>> GetbyModelAsync(string Model)
        {

            List<TblAircraft> dataList = await _iRepo.GetbyModel(Model);
            List<AircraftDM> AircraftList = new List<AircraftDM>();
            AircraftList = dataList.Select(data => new AircraftDM()
            {
                AircraftId = data.AircraftId,
                Make = data.Make,
                Model = data.Model,
                Registration = data.Registration,
                CreatedBy = data.CreatedBy,
                CreatedAt = data.CreatedAt,
                ModifiedAt = data.ModifiedAt,
                ModifiedBy = data.ModifiedBy,
                DeletedAt = data.DeletedAt
            }).ToList();
            return AircraftList;

        }


        public async Task<List<AircraftDM>> GetbyRegistrationAsync(string Registration)
        {
            List<TblAircraft> dataList = await _iRepo.GetbyRegistration(Registration);
            List<AircraftDM> AircraftList = new List<AircraftDM>();
            AircraftList = dataList.Select(data => new AircraftDM()
            {
                AircraftId = data.AircraftId,
                Make = data.Make,
                Model = data.Model,
                Registration = data.Registration,
                CreatedBy = data.CreatedBy,
                CreatedAt = data.CreatedAt,
                ModifiedAt = data.ModifiedAt,
                ModifiedBy = data.ModifiedBy,
                DeletedAt = data.DeletedAt
            }).ToList();
            return AircraftList;
        }

        public async Task<bool> UpdateAsync(AircraftDM dataDM)
        {

            var obj = new TblAircraft();
            obj.AircraftId = dataDM.AircraftId;
            obj.Make = dataDM.Make;
            obj.Model = dataDM.Model;
            obj.Registration = dataDM.Registration;
            obj.CreatedBy = dataDM.CreatedBy;
            obj.CreatedAt = DateTime.UtcNow;

            var results = await _iRepo.Update(obj);
            return results;
        }
    }
}
