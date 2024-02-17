using SimplePlugin.Plugin2.Service.Test;

namespace SimplePlugin.Plugin2.API.Test
{
    public static class StartUp
    {
        public static int? Priority { get; } = 3;

        public static IApplicationBuilder Configure(this IApplicationBuilder app)
        {
            Console.WriteLine("Plugin2 Configure");
            app.UseMiddleware<Plugin2Test2Middleware>();

            app.UseMiddleware<Plugin2Test1Middleware>();
            return app;
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            Console.WriteLine("Plugin2 ConfigureServices");
            services.AddTransient<IPlugin2Service, Plugin2Service>();
        }
    }
}
