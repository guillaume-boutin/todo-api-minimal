using Application.Actions;
using Application.Models;
using Application.Repositories;
using Infrastructure.MySQL;
using Microsoft.EntityFrameworkCore;

namespace UI.Web.Handlers
{
    public static class TodoHandlers
    {
        public static void RegisterTodoHandlers(this WebApplication app)
        {
            app.MapGet("/todo", List);
            app.MapGet("/todo/{id}", Get);
            app.MapPost("/todo", Create);
            app.MapPut("/todo/{id}", Update);

            app.MapGet("/todo/complete", async (MySQLContext db) =>
                await db.Todos.Where(t => t.IsComplete).ToListAsync()
            );
        }

        private static async Task<IResult> List(ListTodos action)
        {
            var todos = await action.Run();

            return Results.Ok(todos);
        }

        private static async Task<IResult> Get(int id, GetTodo action)
        {
            var todo = await action.Run(id);
            if (todo is null) return Results.NotFound();

            return Results.Ok(todo);
        }

        private static async Task<IResult> Create(WriteTodoModel model, CreateTodo action)
        {
            var todo = await action.Run(model);

            return Results.Created($"/todo/{todo.Id}", todo);
        }

        private static async Task<IResult> Update(
            int id,
            WriteTodoModel model,
            ITodoRepository repo,
            UpdateTodo action)
        {
            var todo = await repo.Get(id);
            if (todo is null) return Results.NotFound();
            
            todo = await action.Run(id, model);
            return Results.Ok(todo);
        }
    }
}