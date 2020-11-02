using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Models;

namespace ToDoApp.Data.Repositories
{
    public class TodoItemGroupRepository : Repository<ToDoItemGroup>, ITodoItemGroupRepository
    {
        public TodoItemGroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<ToDoItemGroup>> ListFilteredAsync(string userId)
        {
            return await _dbContext.ToDoItemGroups.Where(p => p.UserId == userId).ToListAsync();
        } 
    }
}
