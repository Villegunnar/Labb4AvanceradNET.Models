
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvanceradNET.Models
{
    public class WebbsiteRepository : IProgramRepository<Webbsite>
    {
        private ProgramDbContext _appContext;
        public WebbsiteRepository(ProgramDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Webbsite> Add(Webbsite newEntity)
        {
            var result = await _appContext.Webbsites.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Webbsite> Delete(int id)
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

        public async Task<IEnumerable<Webbsite>> GetAll()
        {

            return await _appContext.Webbsites.ToListAsync();
        }

        public async Task<Webbsite> GetSingel(int id)
        {
            return await _appContext.Webbsites
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Webbsite> Update(Webbsite Entity)
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
    }
}
