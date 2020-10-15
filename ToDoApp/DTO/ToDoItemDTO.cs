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
        public DateTime? ModificationDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ToDoItemGroupId { get; set; }
        public int UserId { get; set; }

        public ToDoItemGroup ToDoItemGroup { get; set; }



    }
}
