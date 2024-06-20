using ASP.NET_Demo_App.TODOS;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITaskService>(new InMemoryTaskService());

var app = builder.Build();
app.UseMiddleware<LoggingMiddleware>();
app.UseRewriter(new RewriteOptions().AddRedirect("tasks/(.*)", "todos/$1"));

app.MapTodosEndpoints();

app.Run();
