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
        public async Task AddAsync(ToDoItem toDoItem)
        {
           await toDoRepository.AddAsync(toDoItem);
           await toDoRepository.SaveAsync();
        }

        public async Task DeleteAsync(ToDoItem toDoItem)
        {
            toDoRepository.Delete(toDoItem);
            await toDoRepository.SaveAsync();
        }

        public Task<ToDoItem> GetToDoItemById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<ToDoItem>> ListAll()
        {
            return await toDoRepository.ListAllAsync();
        }

        public async Task UpdateAsync(ToDoItem toDoItem)
        {
            toDoRepository.Update(toDoItem);
            await toDoRepository.SaveAsync();
        }
    }
}
