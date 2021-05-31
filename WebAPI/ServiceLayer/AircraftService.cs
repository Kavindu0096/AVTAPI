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
    public class AircraftService : IService<AircraftDM>
    {
        private readonly IRepo<TblAircraft> _iRepo;
        public AircraftService(IRepo<TblAircraft> iRepo)
        {
            _iRepo = iRepo;
        }

        public async Task<bool> AddAsync(AircraftDM dataDM)
        {
            try
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
            catch (Exception ex)
            {
                return false;
            }
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AircraftDM>> GetAllAsync()
        {
            try
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
            catch (Exception ex)
            {           
                return null;
            }
        }

        public Task<AircraftDM> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(AircraftDM dataDN)
        {
            throw new NotImplementedException();
        }
    }
}
