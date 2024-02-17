namespace SimplePlugin.Plugin2.API.Test
{
    public class Plugin2Test1Middleware
    {
        private readonly RequestDelegate _next;
        public Plugin2Test1Middleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Plugin2Test1Middleware");
            await _next(context);
        }
    }
    public class Plugin2Test2Middleware
    {
        private readonly RequestDelegate _next;
        public Plugin2Test2Middleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Plugin2Test2Middleware");
            await _next(context);
        }
    }
}
