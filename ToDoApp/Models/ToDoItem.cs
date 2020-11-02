using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Models
{
    public class ToDoItem
    {
        public ToDoItem()
        {
            CreateDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; } = false;
        public string Description { get; set; }

        public int ToDoItemGroupId { get; set; }
        public string UserId { get; set; }
        
        public ToDoItemGroup ToDoItemGroup { get; set; }
        public ApplicationUser User { get; set; }
    } 
}
