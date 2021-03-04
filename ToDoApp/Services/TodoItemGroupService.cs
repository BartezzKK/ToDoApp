using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class TodoItemGroupService : ITodoItemGroupService
    {
        private ITodoItemGroupRepository todoItemGroupRepository;

        public TodoItemGroupService(ITodoItemGroupRepository todoItemGroupRepository)
        {
            this.todoItemGroupRepository = todoItemGroupRepository;
        }

        //useless?? AddItemGroupAsync instead of this
        //public async Task AddGroupAsync(ToDoItemGroup toDoItemGroup)
        //{
        //    await todoItemGroupRepository.AddAsync(toDoItemGroup);
        //}

        public async Task<ToDoItemGroup> GetToDoItemGroupByIdAsync(int id)
        {
            return await todoItemGroupRepository.GetByIdAsync(id);
        }

        public async Task<ToDoItemGroup> AddItemGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            await todoItemGroupRepository.AddAsync(toDoItemGroup);
            await todoItemGroupRepository.SaveAsync();
            return toDoItemGroup;
        }

        public async Task DeleteItemGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            todoItemGroupRepository.Delete(toDoItemGroup);
            await todoItemGroupRepository.SaveAsync();
        }

        public async Task UpdateItemGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            todoItemGroupRepository.Update(toDoItemGroup);
            await todoItemGroupRepository.SaveAsync();
        }

        public async Task<IReadOnlyList<ToDoItemGroup>> ListAllGroupAsync()
        {
            return await todoItemGroupRepository.ListAllAsync();
        }
    }
}
