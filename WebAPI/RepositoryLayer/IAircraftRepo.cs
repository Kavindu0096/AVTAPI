using RepositoryLayer.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IAircraftRepo
    {
        Task<bool> Add(TblAircraft Aircraft);
        Task<bool> Update(TblAircraft Aircraft);
        Task<List<TblAircraft>> GetAll();
        Task< TblAircraft> GetbyID(int id);
        Task<bool> Delte(int id);

    }
}
