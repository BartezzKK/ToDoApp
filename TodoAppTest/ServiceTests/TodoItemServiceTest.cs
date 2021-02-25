using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Models;
using ToDoApp.Services;

namespace TodoAppTest.ServiceTests
{
    [TestFixture]
    class TodoItemServiceTest
    {


        [SetUp]
        public void SetUp()
        {
            todoItemRepository = A.Fake<ITodoItemRepository>();
            todoItemService = new TodoItemService(todoItemRepository);
        }

        [Test]
        public async Task AddItemAsyncTest()
        {
            A.CallTo(() => todoItemRepository.AddAsync(A<ToDoItem>.Ignored)).DoesNothing();
            A.CallTo(() => todoItemRepository.SaveAsync()).Returns(1);

            var resultTodoItem = await todoItemService.AddItemAsync(sampleTodoItem);
            A.CallTo(() => todoItemRepository.SaveAsync()).MustHaveHappenedOnceExactly();

            Assert.That(resultTodoItem, Is.EqualTo(sampleTodoItem));

        }

        [Test]
        public async Task DeleteItemAsyncTest()
        {
            await todoItemService.DeleteItemAsync(sampleTodoItem);
            A.CallTo(() => todoItemRepository.Delete(A<ToDoItem>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => todoItemRepository.SaveAsync()).MustHaveHappenedOnceExactly();
        }

        [Test] 
        public async Task UpdateItemAsyncTest()
        {
            await todoItemService.UpdateItemAsync(sampleTodoItem);
            A.CallTo(() => todoItemRepository.Update(sampleTodoItem)).MustHaveHappenedOnceExactly();
            A.CallTo(() => todoItemRepository.SaveAsync()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task GetTodoItemByIdAsyncTest()
        {
            //Arrange
            int todoItemId = 1;
            var todoItem = sampleTodoItem;
            int resultTodoId = 1;

            A.CallTo(() => todoItemRepository.GetByIdAsync(A<int>.Ignored))
                .Invokes((int todoIdArg) =>
                {
                    resultTodoId = todoIdArg;
                })
                .Returns(todoItem);

            //Act
            var resultTodoItem = await todoItemService.GetToDoItemByIdAsync(todoItemId);

            //Assert
            A.CallTo(() => todoItemRepository.GetByIdAsync(A<int>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.IsInstanceOf(typeof(ToDoItem), resultTodoItem);
            Assert.That(resultTodoId, Is.EqualTo(todoItemId));
            Assert.That(resultTodoItem, Is.EqualTo(todoItem));

        }

        private ITodoItemRepository todoItemRepository;
        private TodoItemService todoItemService;
        private ToDoItem sampleTodoItem = new ToDoItem
        {
            Id = 5,
            Description = " Test Description",
            IsDone = true,
            Title = "Test title",
            ModificationDate = new DateTime(2020, 01, 01),
            ToDoItemGroup = new ToDoItemGroup
            {
                Name = "test group name",
                CreateDate = new DateTime(2021, 01, 02),
                User = new ApplicationUser
                {
                    UserName = "test username",
                    NormalizedUserName = "test",
                },
                UserId = "userId"
            }
        };
    }
}
