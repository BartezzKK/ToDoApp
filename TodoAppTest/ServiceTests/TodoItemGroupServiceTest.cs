using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Data.Repositories.Interfaces;
using ToDoApp.Models;
using ToDoApp.Services;

namespace TodoAppTest.UnitTests.ServiceTests
{
    [TestFixture]
    class TodoItemGroupServiceTest
    {

        [SetUp]
        public void SetUp()
        {
            todoItemGroupRepository = A.Fake<ITodoItemGroupRepository>();
            todoItemGroupService = new TodoItemGroupService(todoItemGroupRepository);
        }

        [Test]
        public async Task AddItemGroupAsyncTest()
        {

            A.CallTo(() => todoItemGroupRepository.AddAsync(A<ToDoItemGroup>.Ignored)).DoesNothing();

            var resultGroup = await todoItemGroupService.AddItemGroupAsync(sampleGroup);
            A.CallTo(() => todoItemGroupRepository.SaveAsync()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task DeleteItemGroupAsync()
        {
            ToDoItemGroup todogroup = sampleGroup;

            await todoItemGroupService.DeleteItemGroupAsync(sampleGroup);

            A.CallTo(() => todoItemGroupRepository.Delete(A<ToDoItemGroup>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => todoItemGroupRepository.SaveAsync()).MustHaveHappenedOnceExactly();
        }

        [Test]
        public async Task UpdateItemGroupAsyncTest()
        {
            ToDoItemGroup todogroup = sampleGroup;

            await todoItemGroupService.UpdateItemGroupAsync(sampleGroup);

            A.CallTo(() => todoItemGroupRepository.Update(A<ToDoItemGroup>.Ignored)).MustHaveHappenedOnceExactly();
            A.CallTo(() => todoItemGroupRepository.SaveAsync()).MustHaveHappenedOnceExactly();

        }

        [Test]
        public async Task GetToDoItemGroupByIdTest()
        {
            int todoItemGroupId = 1;
            var todoItemGroup = sampleGroup;
            int resultTodoItemGroupId = 1;

            A.CallTo(() => todoItemGroupRepository.GetByIdAsync(A<int>.Ignored))
                .Invokes((int todoItemGroupIdArg) =>
                {
                    resultTodoItemGroupId = todoItemGroupIdArg;
                }).Returns(todoItemGroup);

            var resultTodoItemGroup = await todoItemGroupService.GetToDoItemGroupByIdAsync(todoItemGroupId);

            A.CallTo(() => todoItemGroupRepository.GetByIdAsync(A<int>.Ignored)).MustHaveHappenedOnceExactly();

            Assert.IsInstanceOf(typeof(ToDoItemGroup), resultTodoItemGroup);
            Assert.That(resultTodoItemGroupId, Is.EqualTo(todoItemGroupId));
            Assert.That(resultTodoItemGroup, Is.EqualTo(todoItemGroup));
        }

        private ITodoItemGroupRepository todoItemGroupRepository;
        private TodoItemGroupService todoItemGroupService;
        private ToDoItemGroup sampleGroup = new ToDoItemGroup
        {
            Name = "Test name",
            Id = 1,
            CreateDate = DateTime.Now,
            User = new ApplicationUser
            {
                Id = "TestUserId",
                NormalizedUserName = "Test name",
            },
            UserId = "TestUserId"
        };
    }
}
