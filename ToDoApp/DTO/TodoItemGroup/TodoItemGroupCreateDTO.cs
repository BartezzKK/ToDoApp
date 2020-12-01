
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.DTO.TodoItemGroup
{
    public class ToDoItemGroupCreateDTO
    {
        public ToDoItemGroupCreateDTO()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }


        public ToDoItemGroup ConvertIntoToDoItemGroup()
        {
            return new ToDoItemGroup
            {
                Id = Id,
                Name = Name,
                //UserId = UserId
            };
        }

        public static ToDoItemGroupCreateDTO ConvertIntoToDoItemGroupDTO(ToDoItemGroup toDoItemGroup)
        {
            var toDoItemGroupDTO = new ToDoItemGroupCreateDTO
            {
                Id = toDoItemGroup.Id,
                Name = toDoItemGroup.Name,
                //UserId =  toDoItemGroup.UserId
            };

            return toDoItemGroupDTO;
        }
    }
}
