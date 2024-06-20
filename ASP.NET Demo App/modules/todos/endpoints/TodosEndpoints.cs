using Microsoft.AspNetCore.Http.HttpResults;

namespace ASP.NET_Demo_App.TODOS
{
    public static class TodosModule
    {
        public static IEndpointRouteBuilder MapTodosEndpoints(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/todos", (ITaskService service) => Results.Ok(service.GetTodos()));

            endpoints.MapGet("/todos/{id}", Results<Ok<Todo>, NotFound> (int id, ITaskService service) =>
            {
                var task = service.GetTodoById(id);
                if (task is null) return TypedResults.NotFound();
                return TypedResults.Ok(task);
            });

            endpoints.MapPost("/todos", (Todo task, ITaskService service) =>
            {
                var newTask = service.AddTodo(task);
                return TypedResults.Created($"/todos/{task.Id}", newTask);
            }).AddEndpointFilter(TodoValidationFilter.ValidateTodo);

            endpoints.MapPut("/todos/{id}", Results<Ok<Todo>, NotFound> (int id, Todo task, ITaskService service) =>
            {
                var updatedTask = service.UpdateTodoById(id, task);
                return TypedResults.Ok(updatedTask);
            });

            endpoints.MapDelete("/todos/{id}", (int id, ITaskService service) =>
            {
                service.RemoveTodoById(id);
                return TypedResults.NoContent();
            });

            return endpoints;
        }
    }
}