using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoItemGroupController : ControllerBase
    {

        // GET: <ToDoItemGroupController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
