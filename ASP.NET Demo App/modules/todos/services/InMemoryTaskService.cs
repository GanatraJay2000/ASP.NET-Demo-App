namespace ASP.NET_Demo_App.TODOS
{
    public class InMemoryTaskService : ITaskService
    {
        private readonly List<Todo> _todos = [];

        public Todo AddTodo(Todo task)
        {
            _todos.Add(task);
            return task;
        }

        public Todo? GetTodoById(int id) => _todos.SingleOrDefault(t => t.Id == id);

        public List<Todo> GetTodos() => _todos;

        public void RemoveTodoById(int id) => _todos.RemoveAll(t => t.Id == id);

        public Todo? UpdateTodoById(int id, Todo task)
        {
            var existingTask = _todos.SingleOrDefault(t => t.Id == id);
            if (existingTask is null) return null;
            _todos.Remove(existingTask);
            _todos.Add(task);
            return task;
        }
    }
}