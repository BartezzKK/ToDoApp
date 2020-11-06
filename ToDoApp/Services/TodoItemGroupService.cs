using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class TodoItemGroupService : ITodoItemGroupService
    {
        private ITodoItemGroupRepository _toDoItemGroupRepo;

        public TodoItemGroupService(ITodoItemGroupRepository todoItemGroupRepository)
        {
            _toDoItemGroupRepo = todoItemGroupRepository;
        }
        public async Task AddGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            await _toDoItemGroupRepo.AddAsync(toDoItemGroup);
        }

        public async Task<ToDoItemGroup> GetToDoItemGroupByIdAsync(int id)
        {
            return await _toDoItemGroupRepo.GetByIdAsync(id);
        }

        public async Task AddItemGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            await _toDoItemGroupRepo.AddAsync(toDoItemGroup);
        }

        public async Task DeleteItemGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            await _toDoItemGroupRepo.Delete(toDoItemGroup);
        }

        public async Task UpdateItemGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            await _toDoItemGroupRepo.Update(toDoItemGroup);
        }

        public async Task<IReadOnlyList<ToDoItemGroup>> ListAllGroupAsync()
        {
            return await _toDoItemGroupRepo.ListAllAsync();
        }
    }
}
