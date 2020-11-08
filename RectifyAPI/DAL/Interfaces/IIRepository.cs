using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    // an abstraction layer over different ORMs
    public interface IRepository<T> 
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
