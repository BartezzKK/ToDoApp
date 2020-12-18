using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DTO.TodoItem;
using ToDoApp.Models;

namespace ToDoApp.Profiles
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<ToDoItem, TodoItemReadDTO>();
            CreateMap<TodoItemCreateDTO, ToDoItem>();
            CreateMap<TodoItemUpdateDTO, ToDoItem>();
            CreateMap<ToDoItem, TodoItemCreateDTO>();
        }
    }
}
