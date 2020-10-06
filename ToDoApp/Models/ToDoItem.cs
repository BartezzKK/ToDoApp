using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Display(Name = "Data utworzenia")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "Data modyfikacji")]
        public DateTime? ModificationDate { get; set; }

        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Display(Name = "Opis")]
        public string Description { get; set; }

        [Display(Name = "Grupa")]
        public int ToDoItemGroupId { get; set; }

        [Display(Name = "Użytkownik")]
        public int UserId { get; set; }

        public virtual ToDoItemGroup Group { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

    } 
}
