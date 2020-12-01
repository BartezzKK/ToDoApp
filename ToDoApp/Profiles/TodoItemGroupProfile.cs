using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.DTO;
using ToDoApp.DTO.TodoItemGroup;
using ToDoApp.Models;

namespace ToDoApp.Profiles
{
    public class TodoItemGroupProfile : Profile
    {
        public TodoItemGroupProfile()
        {
            //mapping data from domain into dto
            CreateMap<ToDoItemGroup, TodoItemGroupReadDTO>();
            //mapping data from dto to domain
            CreateMap<ToDoItemGroupCreateDTO, ToDoItemGroup>();
            //mapping data from dto into domain for update
            CreateMap<TodoItemGroupUpdateDTO, ToDoItemGroup>();
        }
    }
}
