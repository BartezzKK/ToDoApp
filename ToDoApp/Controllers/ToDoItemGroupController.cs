using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ToDoApp.DTO;
using ToDoApp.Models;
using ToDoApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoItemGroupController : ControllerBase
    {
        private readonly ITodoItemGroupService todoItemGroupService;
        private readonly ILogger<ToDoItemGroupController> logger;

        public ToDoItemGroupController(ITodoItemGroupService todoItemGroupService, ILogger<ToDoItemGroupController> logger)
        {
            this.todoItemGroupService = todoItemGroupService;
            this.logger = logger;
        }
        // GET: <ToDoItemGroupController>
        [HttpGet]
        public async Task<IEnumerable<ToDoItemGroupDTO>> Get()
        {
            var result = await todoItemGroupService.ListAllGroupAsync();
            return result.Select(ToDoItemGroupDTO.ConvertIntoToDoItemGroupDTO);
        }

        // GET <ToDoItemGroupController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST <ToDoItemGroupController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <ToDoItemGroupController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <ToDoItemGroupController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
