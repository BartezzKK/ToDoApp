using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Services
{
    public interface ITodoItemGroupService
    {
        Task<ToDoItemGroup> GetToDoItemGroupByIdAsync(int id);
        Task<ToDoItemGroup> AddItemGroupAsync(ToDoItemGroup toDoItem);
        Task DeleteItemGroupAsync(ToDoItemGroup toDoItem);
        Task UpdateItemGroupAsync(ToDoItemGroup toDoItem);
        Task<IReadOnlyList<ToDoItemGroup>> ListAllGroupAsync();
        Task<IReadOnlyList<ToDoItemGroup>> ListFilteredByUserId(string userId);
    }
}
