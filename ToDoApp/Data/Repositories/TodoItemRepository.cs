using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Data.Repositories
{
    public class TodoItemRepository : Repository<ToDoItem>, ITodoItemRepository
    {
        public TodoItemRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<ToDoItem>> ListFilteredAsync(int groupId)
        {
            return await _dbContext.ToDoItems.Where(i => i.ToDoItemGroupId == groupId).ToListAsync();
        }
    }
}
