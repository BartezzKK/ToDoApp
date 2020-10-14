using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public interface IToDoService
    {
        Task<ToDoItem> GetToDoItemById(int id);
        Task AddAsync(ToDoItem toDoItem);
        Task DeleteAsync(ToDoItem toDoItem);
        Task UpdateAsync(ToDoItem toDoItem);
        Task<IReadOnlyList<ToDoItem>> ListAll();

    }
}