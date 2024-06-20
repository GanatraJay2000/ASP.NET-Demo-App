namespace ASP.NET_Demo_App.TODOS
{
    public record Todo(int Id, string Name, DateTime DueDate, bool IsCompleted);
}