using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoApp.DTO.TodoItemGroup;
using ToDoApp.Models;
using ToDoApp.Services;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoItemGroupController : ControllerBase
    {
        private readonly ITodoItemGroupService todoItemGroupService;
        private readonly ILogger<ToDoItemGroupController> logger;
        private readonly IMapper mapper;

        public ToDoItemGroupController(ITodoItemGroupService todoItemGroupService,
            ILogger<ToDoItemGroupController> logger,
            IMapper mapper)
        {
            this.todoItemGroupService = todoItemGroupService;
            this.logger = logger;
            this.mapper = mapper;
        }
        // GET: <ToDoItemGroupController>
        [HttpGet]
        public async Task<IEnumerable<TodoItemGroupReadDTO>> GetAllAsync()
        {
            var result = await todoItemGroupService.ListAllGroupAsync();
            return mapper.Map<IEnumerable<TodoItemGroupReadDTO>>(result);
        }

        // GET <ToDoItemGroupController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemGroup>> Get(int id)
        {
           var result = await todoItemGroupService.GetToDoItemGroupByIdAsync(id);
            if (result != null)
            {
                return Ok(mapper.Map<TodoItemGroupReadDTO>(result));
            }
            else return NotFound();
        }

        // POST <ToDoItemGroupController>
        [HttpPost]
        public async Task<ActionResult<ToDoItemGroupCreateDTO>> CreateGroup(ToDoItemGroupCreateDTO dtoItemGroup)
        {
            if(dtoItemGroup == null)
            { 
                return UnprocessableEntity();
            }
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            dtoItemGroup.UserId = userId;
            var result = mapper.Map<ToDoItemGroup>(dtoItemGroup);
            await todoItemGroupService.AddItemGroupAsync(result);

            var createdItemGroup = mapper.Map<TodoItemGroupReadDTO>(result);
            return Ok(createdItemGroup);
        }

        // PUT <ToDoItemGroupController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ToDoItemGroupCreateDTO dtoGroup)
        {
            // sprawdzić dlaczego angular nie przekazuje tego id do dtoGroup


            dtoGroup.Id = id;
            var group = await todoItemGroupService.GetToDoItemGroupByIdAsync(id);
            if(group == null)
            {
                return NotFound();
            }
            mapper.Map(dtoGroup, group);

            await todoItemGroupService.UpdateItemGroupAsync(group);
            return NoContent();
        }

        // DELETE <ToDoItemGroupController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await todoItemGroupService.GetToDoItemGroupByIdAsync(id);
            if(item == null)
            {
                return NotFound();
            }
            await todoItemGroupService.DeleteItemGroupAsync(item);
            return Ok();
        }
    }
}
