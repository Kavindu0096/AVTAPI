using Microsoft.EntityFrameworkCore;
using RepositoryLayer.DB;
using System;
using System.Collections.Generic;
 
using System.Linq;
 
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class AircraftSightingRepo : IAircraftSightingRepo
    {
        private readonly AVTContext _context;
      
        public AircraftSightingRepo(AVTContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(TblAircraftSighting data)
        {
            try
            {
                await _context.TblAircraftSightings.AddAsync(data);
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
                var data = new TblAircraftSighting { Id = id };
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

        public async Task<List<TblAircraftSighting>> GetAll()
        {
            List<TblAircraftSighting> TblAircraftSighting_List = new List<TblAircraftSighting>();
            //removing redords flagged with delete
            TblAircraftSighting_List = await _context.TblAircraftSightings.Where(t=>t.DeletedAt==null).ToListAsync();

            //remove data flaged as deleted 
            var results = TblAircraftSighting_List.Where(t => t.DeletedAt == null).ToList();
            return results;
        }

        public async Task<TblAircraftSighting> GetbyID(long id)
        {
            var results = await _context.TblAircraftSightings.Where(t => t.Id == id).FirstOrDefaultAsync();
            return results;
        }

        public async Task<bool> Update(TblAircraftSighting data)
        {
            try
            {
                _context.TblAircraftSightings.Update(data);
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
