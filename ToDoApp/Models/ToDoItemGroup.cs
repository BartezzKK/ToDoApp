using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;   
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class ToDoItemGroup
    {
        public ToDoItemGroup()
        {
            CreateDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }

        public ApplicationUser User { get; set; }
    }
}
