using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<TodoItemGroupReadDTO>> GetAllByUserId()
        {

            var userId = GetUserId();
            if (userId != null)
            {
                var result = await todoItemGroupService.ListFilteredByUserId(userId);
                if (result != null)
                {
                    return mapper.Map<IEnumerable<TodoItemGroupReadDTO>>(result);
                }
                else return null;
            }
            else return null;
        }

        // GET <ToDoItemGroupController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemGroup>> Get(int id)
        {
           var result = await todoItemGroupService.GetToDoItemGroupByIdAsync(id);

            if (result != null && IsTheOwnerOfTheGroup(result))
            {
                return Ok(mapper.Map<TodoItemGroupReadDTO>(result));
            }
            else return NotFound();
        }

        // POST <ToDoItemGroupController>
        [HttpPost]
        public async Task<ActionResult<ToDoItemGroupCreateDTO>> CreateGroup(ToDoItemGroupCreateDTO dtoItemGroup)
        {
            if (dtoItemGroup == null)
            {
                return UnprocessableEntity();
            }
            var userId = GetUserId();
            if (userId != null)
            {
                dtoItemGroup.UserId = userId;
                var result = mapper.Map<ToDoItemGroup>(dtoItemGroup);
                await todoItemGroupService.AddItemGroupAsync(result);

                var createdItemGroup = mapper.Map<TodoItemGroupReadDTO>(result);
                return Ok(createdItemGroup);
            }

            else return Unauthorized();
        }

        // PUT <ToDoItemGroupController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ToDoItemGroupCreateDTO dtoGroup)
        {
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
            if (IsTheOwnerOfTheGroup(item))
            {
                if (item == null)
                {
                    return NotFound();
                }
                await todoItemGroupService.DeleteItemGroupAsync(item);
                return Ok();
            }
            else return Unauthorized();
        }

        /// <summary>
        /// Check current logged user ID
        /// </summary>
        /// <returns>
        /// Return user ID as string
        /// </returns>
        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        /// <summary>
        /// Validate UserId property of ToDoItemGroup and equal it to current user ID
        /// </summary>
        /// <param name="group">Object of ToDoItemGroup</param>
        /// <returns>Return true if UserId of group is equal to current user ID otherwise return false</returns>
        private bool IsTheOwnerOfTheGroup(ToDoItemGroup group)
        {
            string userId = GetUserId();
            if (userId == group.UserId)
            {
                return true;
            }
            else return false;
        }
    }
}
