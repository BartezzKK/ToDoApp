using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Data.Repositories
{
    public interface IToDoRepository<T>
    {
        void Add(T entity);
        Task AddAsync(T entity);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        IReadOnlyList<T> ListAll();
        Task<IReadOnlyList<T>> ListAllAsync();
        void Delete(T entity);
        void Update(T entity);
    }
}