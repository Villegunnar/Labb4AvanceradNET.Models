using Labb4AvanceradNET.API.Models;
using Labb4AvanceradNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvanceradNET.API.Services
{
    public class WebsiteRepository : IProgramRepository<Website>
    {
        private ProgramDbContext _appContext;
        public WebsiteRepository(ProgramDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Website> Add(Website newEntity)
        {
            var result = await _appContext.Webbsites.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Website> Delete(int id)
        {
            var result = await _appContext.Webbsites.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                _appContext.Webbsites.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Website>> GetAll()
        {

            return await _appContext.Webbsites.ToListAsync();
        }

        public async Task<Website> GetSingel(int id)
        {
            return await _appContext.Webbsites
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Website> Update(Website Entity)
        {
            var result = await _appContext.Webbsites.FirstOrDefaultAsync(p => p.Id == Entity.Id);
            if (result != null)
            {

                result.WebbsiteName = Entity.WebbsiteName;
                result.WebbsiteAdress = Entity.WebbsiteAdress;
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        Task<IEnumerable<Website>> IProgramRepository<Website>.GetUserWithInterests(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Website>> GetUserWithWebbsites(int id)
        {
   
            /*return await _appContext.Webbsites.Where(u=> u.Interest.UserId == id).Include(u => u.Interest.User).ToListAsync();*/           //<--- hämtar alla webbsites med user 

            return await _appContext.Webbsites.Where(i => i.Interest.UserId == id).ToArrayAsync();                                // <---- hämtar bara webbsites tillhörande specifikt userid

      
        }

        public async Task<IEnumerable<Website>> GetUserWithInterestWebbsites(int id)
        {
            return await _appContext.Webbsites.Where(u => u.Interest.UserId == id).Include(u => u.Interest.User).ToListAsync();
        }

        Task<IEnumerable<Website>> IProgramRepository<Website>.SearchUsers(string name)
        {
            throw new NotImplementedException();
        }
    }
}
