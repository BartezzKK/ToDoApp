using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Data.Repositories
{
    public interface IRepository<T>
    {
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task Delete(T entity);
        Task Update(T entity);
    }
}