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
    public class ToDoItemController : ControllerBase
    {
        private readonly ITodoItemService toDoService;
        private readonly ILogger<ToDoItemController> logger;

        public ToDoItemController(ITodoItemService toDoService, ILogger<ToDoItemController> logger)
        {
            this.toDoService = toDoService;
            this.logger = logger;
        }
        // GET: <ToDoItemController>
        [HttpGet]
        public async Task<IEnumerable<ToDoItemDTO>> GetAsync()
        {
            var result = await toDoService.ListAllItemsAsync();
            return result.Select(ToDoItemDTO.ConvertIntoToDoItemDTO);
        }

        // GET <ToDoItemController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST <ToDoItemController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT <ToDoItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE <ToDoItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
