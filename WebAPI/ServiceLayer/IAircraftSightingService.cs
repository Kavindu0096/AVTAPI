using InfrastructureLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IAircraftSightingService
    {
        Task<bool> AddAsync(AircraftSightingDM dataDM);
        Task<bool> UpdateAsync(AircraftSightingDM dataDM);
        Task<List<AircraftSightingDM>> GetAllAsync();
        Task<AircraftSightingDM> GetByIdAsync(long id);
        Task<bool> DeleteAsync(int id);
    }
}
