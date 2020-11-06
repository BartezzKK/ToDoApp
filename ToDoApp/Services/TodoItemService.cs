using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class TodoItemService : ITodoItemService
    {
        //private Repository<ToDoItem> toDoItemRepo;
        private readonly ITodoItemRepository _todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        public async Task<ToDoItem> AddItemAsync(ToDoItem toDoItem)
        {
            await _todoItemRepository.AddAsync(toDoItem);
            //await _todoItemRepository.SaveAsync();
            return await _todoItemRepository.AddAsync(toDoItem);
        }

        public async Task DeleteItemAsync(ToDoItem toDoItem)
        {
            await _todoItemRepository.Delete(toDoItem);
            //await _todoItemRepository.SaveAsync();
        }

        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            return await _todoItemRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<ToDoItem>> ListAllItemsAsync()
        {
            return await _todoItemRepository.ListAllAsync();
        }

        public async Task UpdateItemAsync(ToDoItem toDoItem)
        {
            await _todoItemRepository.Update(toDoItem);
            //await _todoItemRepository.SaveAsync();
        }
    }
}
