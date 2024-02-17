namespace SimplePlugin.Plugin1.API.Test
{
    public class Plugin1Test1Middleware
    {
        private readonly RequestDelegate _next;
        public Plugin1Test1Middleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Plugin1Test1Middleware");
            await _next(context); 
        }
    }
    public class Plugin1Test2Middleware
    {
        private readonly RequestDelegate _next;
        public Plugin1Test2Middleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Plugin1Test2Middleware");
            await _next(context);
        }
    }
}
