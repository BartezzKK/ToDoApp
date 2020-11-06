using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.DTO
{
    public class ToDoItemDTO
    {
        public ToDoItemDTO()
        {

        }

        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ToDoItemGroupId { get; set; }
        public string UserId { get; set; }
        public bool IsDone { get; set; }
        public ToDoItemGroup ToDoItemGroup { get; set; }

        public ToDoItem ConvertIntoToDoItem()
        {
            return new ToDoItem
            {
                Id = Id,
                Title = Title,
                Description = Description,
                ToDoItemGroupId = ToDoItemGroupId,
                IsDone = IsDone
            };
        }

        public static ToDoItemDTO ConvertIntoToDoItemDTO(ToDoItem toDoItem)
        {
            var toDoItemDTO = new ToDoItemDTO
            {
                Id = toDoItem.Id,
                CreateDate = toDoItem.CreateDate,
                Title = toDoItem.Title,
                Description = toDoItem.Description,
                ToDoItemGroupId = toDoItem.ToDoItemGroupId,
                UserId = toDoItem.UserId,
                ToDoItemGroup = toDoItem.ToDoItemGroup,
                IsDone = toDoItem.IsDone
            };

            return toDoItemDTO;
        }

    }
}
