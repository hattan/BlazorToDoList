using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDos.Server.Controllers;
using Xunit;

namespace Todos.Test.Server
{
    public class ToDoControllerTests
    {
        [Fact]
        public void Foo()
        {
            //arrange
            var controller = new TodoController();

            //act
            var todos = controller.Index();

            //assert
            Assert.Single(todos);
            Assert.Equal("test 123", todos.FirstOrDefault()?.Name);

        }
    }
}
