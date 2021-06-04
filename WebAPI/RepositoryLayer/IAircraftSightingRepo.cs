using RepositoryLayer.DB;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IAircraftSightingRepo
    {
        Task<bool> Add(TblAircraftSighting data);
        Task<bool> Update(TblAircraftSighting data);
        Task<List<TblAircraftSighting>> GetAll();
        Task<TblAircraftSighting> GetbyID(long id);
        Task<bool> Delete(int id);
    }
}
