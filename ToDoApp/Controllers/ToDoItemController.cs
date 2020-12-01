using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoApp.DTO.TodoItem;
using ToDoApp.Models;
using ToDoApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private readonly ITodoItemService toDoService;
        private readonly ILogger<ToDoItemController> logger;
        private readonly IMapper mapper;

        public ToDoItemController(ITodoItemService toDoService, ILogger<ToDoItemController> logger, IMapper mapper)
        {
            this.toDoService = toDoService;
            this.logger = logger;
            this.mapper = mapper;
        }

        // GET: <ToDoItemController>
        [HttpGet]
        public async Task<IEnumerable<TodoItemReadDTO>> GetAsync() 
        {
            var result = await toDoService.ListAllItemsAsync();
            return mapper.Map<IEnumerable<TodoItemReadDTO>>(result);
        }

        // GET <ToDoItemController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemReadDTO>> Get(int id)
        {
            var result = await toDoService.GetToDoItemByIdAsync(id);
            if (result != null)
            {
                return Ok(mapper.Map<TodoItemReadDTO>(result));
            }
            else return NotFound();
            
        }

        // POST <ToDoItemController>
        [HttpPost]
        public async Task<ActionResult<TodoItemCreateDTO>> CreateItem(TodoItemCreateDTO dtoItem)
        {
            var result =  mapper.Map<ToDoItem>(dtoItem);
            await toDoService.AddItemAsync(result);

            var todoItemCreate = mapper.Map<TodoItemCreateDTO>(result);

            return Ok(todoItemCreate);
        }

        // PUT <ToDoItemController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TodoItemCreateDTO dtoItem)
        {
            var item = await toDoService.GetToDoItemByIdAsync(id);
            if(item == null)
            {
                return NotFound();
            }
            mapper.Map(dtoItem, item);

            await toDoService.UpdateItemAsync(item);
            return NoContent();
        }

        // DELETE <ToDoItemController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var item = await toDoService.GetToDoItemByIdAsync(id);

            if(item == null)
            {
                return NotFound();
            }

            await toDoService.DeleteItemAsync(item);
            return Ok();
        }
    }
}
