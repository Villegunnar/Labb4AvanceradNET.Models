using Labb4AvanceradNET.API.Models;
using Labb4AvanceradNET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvanceradNET.API.Services
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
        public async Task<IEnumerable<User>> AddNewInterestToPerson(User Entity)
        {
            var result = await _appContext.Users.FirstOrDefaultAsync(p => p.Id == Entity.Id);
            if (result != null)
            {

                result.FirstName = Entity.FirstName;
                result.LastName = Entity.LastName;
                result.PhoneNumber = Entity.PhoneNumber;

                await _appContext.SaveChangesAsync();
                return (IEnumerable<User>)result;
            }
            return null;
        }
        Task<IEnumerable<User>> IProgramRepository<User>.GetUserWithWebbsites(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IProgramRepository<User>.GetUserWithInterests(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<User>> IProgramRepository<User>.GetUserWithInterestWebbsites(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> SearchUsers(string name)
        {

            IQueryable<User> query = _appContext.Users;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.FirstName.Contains(name) || c.LastName.Contains(name));
            }

            return await query.ToListAsync();



        }
    }
}

