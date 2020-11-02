using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class TodoItemService : ITodoItemService
    {
        private Repository<ToDoItem> toDoItemRepo;

        public async Task AddItemAsync(ToDoItem toDoItem)
        {
            await toDoItemRepo.AddAsync(toDoItem);
            await toDoItemRepo.SaveAsync();
        }

        public async Task DeleteItemAsync(ToDoItem toDoItem)
        {
            toDoItemRepo.Delete(toDoItem);
            await toDoItemRepo.SaveAsync();
        }

        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            return await toDoItemRepo.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<ToDoItem>> ListAllItemsAsync()
        {
            return await toDoItemRepo.ListAllAsync();
        }

        public async Task UpdateItemAsync(ToDoItem toDoItem)
        {
            toDoItemRepo.Update(toDoItem);
            await toDoItemRepo.SaveAsync();
        }
    }
}
