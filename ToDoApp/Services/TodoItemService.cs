using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository todoItemRepository;

        public TodoItemService(ITodoItemRepository todoItemRepository)
        {
            this.todoItemRepository = todoItemRepository;
        }

        public async Task<ToDoItem> AddItemAsync(ToDoItem toDoItem)
        {
            await todoItemRepository.AddAsync(toDoItem);
            await todoItemRepository.SaveAsync();
            return toDoItem;
        }

        public async Task DeleteItemAsync(ToDoItem toDoItem)
        {
           todoItemRepository.Delete(toDoItem);
           await todoItemRepository.SaveAsync();
        }

        public async Task<ToDoItem> GetToDoItemByIdAsync(int id)
        {
            return await todoItemRepository.GetByIdAsync(id);
        }

        public async Task<IReadOnlyList<ToDoItem>> ListAllItemsAsync()
        {
            return await todoItemRepository.ListAllAsync();
        }

        public async Task UpdateItemAsync(ToDoItem toDoItem)
        {
            todoItemRepository.Update(toDoItem);
            await todoItemRepository.SaveAsync();
        }
    }
}
