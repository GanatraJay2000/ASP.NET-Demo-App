namespace ASP.NET_Demo_App.TODOS
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path} {DateTime.UtcNow} Start");
            await _next(context);
            Console.WriteLine($"Response: {context.Response.StatusCode}");
            Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path} {DateTime.UtcNow} End");
        }
    }
}