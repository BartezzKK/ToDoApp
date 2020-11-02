﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Data.Repositories.Interfaces
{
    public interface ITodoItemRepository : IRepository<ToDoItem>
    {
    }
}
