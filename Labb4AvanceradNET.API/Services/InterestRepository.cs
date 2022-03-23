using Labb4AvanceradNET.API.Models;
using Labb4AvanceradNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvanceradNET.API.Services
{
    public class InterestRepository : IProgramRepository<Interest>
    {
        private ProgramDbContext _appContext;
        public InterestRepository(ProgramDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<Interest> Add(Interest newEntity)
        {
            var result = await _appContext.Interests.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Interest> Delete(int id)
        {
            var result = await _appContext.Interests.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                _appContext.Interests.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Interest>> GetAll()
        {

            return await _appContext.Interests.ToListAsync();
        }

        public async Task<Interest> GetSingel(int id)
        {
            return await _appContext.Interests
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<Interest> Update(Interest Entity)
        {
            var result = await _appContext.Interests.FirstOrDefaultAsync(p => p.Id == Entity.Id);
            if (result != null)
            {

                result.InterestName = Entity.InterestName;
                result.Description = Entity.Description;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }


        public async Task<IEnumerable<Interest>> GetUserWithInterests(int id)
        {


            //return await _appContext.Interests.Include(p => p.User).Where(i => i.UserId == id).ToListAsync(); <---- hämta username med alla kopplade intresse

            return await _appContext.Interests.Where(i => i.UserId == id).ToArrayAsync(); // <---- hämtar bara all intressen kopplade till ett usedId

        }
        Task<IEnumerable<Interest>> IProgramRepository<Interest>.GetUserWithWebbsites(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Interest>> IProgramRepository<Interest>.GetUserWithInterestWebbsites(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Interest>> IProgramRepository<Interest>.SearchUsers(string name)
        {
            throw new NotImplementedException();
        }
    }
}
