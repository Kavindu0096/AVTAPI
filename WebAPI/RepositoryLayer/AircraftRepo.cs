using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class AircraftRepo : IAircraftRepo
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                //flaging record delete without deleting
                var data = new TblAircraft { AircraftId = id };
                data.DeletedAt = DateTime.UtcNow;
                _context.Entry(data).Property("DeletedAt").IsModified = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<List<TblAircraft>> GetAll()
        {

            List<TblAircraft> TblAircraft_List = new List<TblAircraft>();
            //removing redords flagged with delete
            TblAircraft_List = await _context.TblAircrafts.Where(t => t.DeletedAt == null).ToListAsync();

            //remove data flaged as deleted 
            var results = TblAircraft_List.Where(t => t.DeletedAt == null).ToList();
            return results;

        }

        public async Task<TblAircraft> GetbyID(long id)
        {
            var results = await _context.TblAircrafts.Where(t=>t.AircraftId==id).FirstOrDefaultAsync();
            return results;
        }

        public async Task<List<TblAircraft>> GetbyMake(string make)
        {
            var results = await _context.TblAircrafts.Where(t => t.Make == make).ToListAsync();
            return results;
        }
        public async Task<List<TblAircraft>> GetbyModel(string model)
        {
            var results = await _context.TblAircrafts.Where(t => t.Model == model).ToListAsync();
            return results;
        }
        public async Task<List<TblAircraft>> GetbyRegistration(string registration)
        {
            var results = await _context.TblAircrafts.Where(t => t.Registration == registration).ToListAsync();
            return results;
        }

        public async Task<bool> Update(TblAircraft Aircraft)
        {
            try
            {
                  _context.TblAircrafts.Update(Aircraft);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
    }
}
