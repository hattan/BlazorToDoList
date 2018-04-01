using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDos.Shared;

namespace ToDos.Server.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        public static int counter = 0;
        public static int getNextId()
        {
            return ++counter;
        }
        public static List<Todo> Data { get; set; } = new List<Todo>()
            {
                 new Todo{Id=getNextId(),Name="test 123",IsComplete=false}
            };

        [HttpGet("[action]")]
        public IEnumerable<Todo> Index()
        {
            return Data.Where(i => !i.IsComplete ); 
        }

        [HttpPost("[action]")]
        public Todo Save([FromBody] Todo todo)
        {
            todo.Id = getNextId();
            Data.Add(todo);
            return todo;
        }

        [HttpPut("[action]")]
        public void Clear([FromBody] int id)
        {
            var todo = Data.Where(i => i.Id == id).FirstOrDefault();
            if (todo != null)
            {
                todo.IsComplete = true;
            }
        }
    }
}