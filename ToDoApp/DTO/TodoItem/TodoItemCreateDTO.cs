using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.DTO.TodoItem
{
    public class TodoItemCreateDTO
    {
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ToDoItemGroupId { get; set; }
        public string UserId { get; set; }
        public bool IsDone { get; set; }
    }
}
