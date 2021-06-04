using InfrastructureLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IAircraftService 
    {
        Task<bool> AddAsync(AircraftDM dataDM);
        Task<bool> UpdateAsync(AircraftDM dataDM);
        Task<List<AircraftDM>> GetAllAsync();
        Task<AircraftDM> GetByIdAsync(long id);
        Task<bool> DeleteAsync(int id);

        Task<List<AircraftDM>> GetbyMakeAsync(string Make);
        Task<List<AircraftDM>> GetbyModelAsync(string Model);
        Task<List<AircraftDM>> GetbyRegistrationAsync(string Registration);
    }
}
