using ToDoApp.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ToDoItemGroup>()
                .HasMany(p => p.ToDoItems)
                .WithOne(p => p.ToDoItemGroup).HasForeignKey(p => p.ToDoItemGroupId);
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<ToDoItemGroup> ToDoItemGroups { get; set; }
    }
}
