using RepositoryLayer.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IAircraftRepo
    {
        Task<bool> Add(TblAircraft data);
        Task<bool> Update(TblAircraft data);
        Task<List<TblAircraft>> GetAll();
        Task<TblAircraft> GetbyID(long  id);
        Task<List<TblAircraft>> GetbyMake(string Make);
        Task<List<TblAircraft>> GetbyModel(string Model);
        Task<List<TblAircraft>> GetbyRegistration(string Registration);
        Task<bool> Delete(int id);
    }
}
