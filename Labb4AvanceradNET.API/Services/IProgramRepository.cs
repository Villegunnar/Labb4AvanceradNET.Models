using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labb4AvanceradNET.API.Services
{
    public interface IProgramRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingel(int id);
        Task<T> Add(T newEntity);
        Task<T> Update(T Entity);
        Task<T> Delete(int id);

        Task<IEnumerable<T>> GetUserWithInterests(int id);
        Task<IEnumerable<T>> GetUserWithWebbsites(int id);
        Task<IEnumerable<T>> GetUserWithInterestWebbsites(int id);
        Task<IEnumerable<T>> SearchUsers(string name);

        




    }
}
