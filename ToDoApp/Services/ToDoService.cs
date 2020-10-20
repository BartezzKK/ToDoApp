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
        private ToDoRepository<ToDoItem> toDoItemRepo;
        private ToDoRepository<ToDoItemGroup> toDoItemGroupRepo;
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

        //ToDoItemGroup methods
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

        public async  Task DeleteItemGroupAsync(ToDoItemGroup toDoItemGroup)
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
