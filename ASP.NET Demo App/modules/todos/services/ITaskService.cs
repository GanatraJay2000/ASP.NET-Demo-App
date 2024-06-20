namespace ASP.NET_Demo_App.TODOS
{
    public interface ITaskService
    {
        Todo AddTodo(Todo task);
        Todo? GetTodoById(int id);
        List<Todo> GetTodos();
        void RemoveTodoById(int id);
        Todo? UpdateTodoById(int id, Todo task);
    }
}