namespace ASP.NET_Demo_App.TODOS
{
    public class TodoValidationFilter
    {
        public static Func<EndpointFilterInvocationContext, EndpointFilterDelegate, ValueTask<object?>> ValidateTodo = async (context, next) =>
        {
            var taskArgument = context.GetArgument<Todo>(0);
            var errors = new Dictionary<string, string[]>();
            if (taskArgument.DueDate < DateTime.UtcNow)
                errors.Add(nameof(Todo.DueDate), ["Due date must be in the future"]);

            if (taskArgument.IsCompleted)
                errors.Add(nameof(Todo.IsCompleted), ["Task cannot be completed at creation"]);

            if (errors.Count != 0)
                return Results.ValidationProblem(errors);

            return await next(context);
        };
    }
}