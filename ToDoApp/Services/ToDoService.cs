using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class ToDoService : IToDoService
    {
        private ToDoRepository<ToDoItem> toDoRepository;
        public async Task AddItemAsync(ToDoItem toDoItem)
        {
           await toDoRepository.AddAsync(toDoItem);
           await toDoRepository.SaveAsync();
        }

        public async Task DeleteItemAsync(ToDoItem toDoItem)
        {
            toDoRepository.Delete(toDoItem);
            await toDoRepository.SaveAsync();
        }

        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            return await toDoRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<ToDoItem>> ListAllItemsAsync()
        {
            return await toDoRepository.ListAllAsync();
        }

        public async Task UpdateItemAsync(ToDoItem toDoItem)
        {
            toDoRepository.Update(toDoItem);
            await toDoRepository.SaveAsync();
        }
    }
}
