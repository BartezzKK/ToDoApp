using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Data utworzenia")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Użytkownik")]
        public int UserId { get; set; }

        public ICollection<ToDoItem> ToDoItems { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
