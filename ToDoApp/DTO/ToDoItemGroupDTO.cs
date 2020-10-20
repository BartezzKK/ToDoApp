
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.DTO
{
    public class ToDoItemGroupDTO
    {
        public ToDoItemGroupDTO()
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
                //UserId = UserId ?? 0
            };
        }

        public static ToDoItemGroupDTO ConvertIntoToDoItemGroupDTO(ToDoItemGroup toDoItemGroup)
        {
            var toDoItemGroupDTO = new ToDoItemGroupDTO
            {
                Id = toDoItemGroup.Id,
                Name = toDoItemGroup.Name,
                //UserId =  toDoItemGroup.UserId
            };

            return toDoItemGroupDTO;
        }
    }
}
