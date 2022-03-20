
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvanceradNET.Models
{
    public class UserRepository : IProgramRepository<User>
    {
        private ProgramDbContext _appContext;
        public UserRepository(ProgramDbContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<User> Add(User newEntity)
        {
            var result = await _appContext.Users.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> Delete(int id)
        {
            var result = await _appContext.Users.FirstOrDefaultAsync(p => p.Id == id);
            if (result != null)
            {
                _appContext.Users.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetAll()
        {

            return await _appContext.Users.ToListAsync();
        }

        public async Task<User> GetSingel(int id)
        {
            return await _appContext.Users
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<User> Update(User Entity)
        {
            var result = await _appContext.Users.FirstOrDefaultAsync(p => p.Id == Entity.Id);
            if (result != null)
            {

                result.FirstName = Entity.FirstName;
                result.LastName = Entity.LastName;
                result.PhoneNumber = Entity.PhoneNumber;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
