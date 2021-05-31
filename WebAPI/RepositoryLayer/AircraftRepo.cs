using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class AircraftRepo : IRepo<TblAircraft>
    {
        private readonly AVTContext _context;
        public AircraftRepo(AVTContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(TblAircraft Aircraft)
        {
            try
            {
                await _context.TblAircrafts.AddAsync(Aircraft);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public Task<bool> Delte(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TblAircraft>> GetAll()
        {
            
            var results = await _context.TblAircrafts.ToListAsync();


            return results;
        }

        public async Task<TblAircraft> GetbyID(long id)
        {
            var results = await _context.TblAircrafts.Where(t=>t.AircraftId==id).FirstOrDefaultAsync();
            return results;
        }

        public Task<bool> Update(TblAircraft Aircraft)
        {
            throw new NotImplementedException();
        }
    }
}
