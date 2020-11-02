using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public class TodoItemGroupService : ITodoItemGroupService
    {
        private Repository<ToDoItemGroup> toDoItemGroupRepo;
        public async Task AddGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            await toDoItemGroupRepo.AddAsync(toDoItemGroup);
        }

        public async Task<ToDoItemGroup> GetToDoItemGroupByIdAsync(int id)
        {
            return await toDoItemGroupRepo.GetByIdAsync(id);
        }

        public async Task AddItemGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            await toDoItemGroupRepo.AddAsync(toDoItemGroup);
            await toDoItemGroupRepo.SaveAsync();
        }

        public async Task DeleteItemGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            toDoItemGroupRepo.Delete(toDoItemGroup);
            await toDoItemGroupRepo.SaveAsync();
        }

        public async Task UpdateItemGroupAsync(ToDoItemGroup toDoItemGroup)
        {
            toDoItemGroupRepo.Update(toDoItemGroup);
            await toDoItemGroupRepo.SaveAsync();
        }

        public async Task<IReadOnlyList<ToDoItemGroup>> ListAllGroupAsync()
        {
            return await toDoItemGroupRepo.ListAllAsync();
        }
    }
}
