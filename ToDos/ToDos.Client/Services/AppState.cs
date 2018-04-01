using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToDos.Shared;

namespace ToDos.Client.Services
{
    public class AppState
    {
        public List<Todo> Todos { get; private set; }

        public event Action OnChange;

        private readonly HttpClient http;
        public AppState(HttpClient httpInstance)
        {
            http = httpInstance;
        }

        public async Task FetchTodos()
        {
            Todos = await http.GetJsonAsync<List<Todo>>("/api/todo/index");
            NotifyStateChanged();
        }

        public async Task AddTodo(string name)
        {
            var todo = new Todo { Name = name };
            todo = await http.PostJsonAsync<Todo>("/api/todo/save",todo);
            Todos.Add(todo);
            NotifyStateChanged();
        }

        public async Task ClearTodo(int todoId)
        {
            var todo = Todos.Where(i => i.Id == todoId).FirstOrDefault();
            if(todo!=null)
            {
                Todos.Remove(todo);
                NotifyStateChanged();
            }

            await http.PutJsonAsync<Todo>("/api/todo/clear", todoId);
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
