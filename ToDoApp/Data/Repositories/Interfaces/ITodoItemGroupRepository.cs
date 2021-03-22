using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Data.Repositories.Interfaces
{
    public interface ITodoItemGroupRepository : IRepository<ToDoItemGroup>
    {
        Task<IReadOnlyList<ToDoItemGroup>> ListFilteredAsync(string userId);
    }
}
