using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public interface IToDoService
    {
        Task<ToDoItem> GetToDoItemByIdAsync(int id);
        Task AddItemAsync(ToDoItem toDoItem);
        Task DeleteItemAsync(ToDoItem toDoItem);
        Task UpdateItemAsync(ToDoItem toDoItem);
        Task<IReadOnlyList<ToDoItem>> ListAllItemsAsync();

    }
}