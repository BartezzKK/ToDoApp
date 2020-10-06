using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Data.Configuration
{
    public class ToDoItemConfiguration : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoItemGroup>()
                .HasMany(p => p.ToDoItems)
                .WithOne();


        }
    }
}
