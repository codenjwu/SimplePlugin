using SimplePlugin.Plugin1.Service.Test;

namespace SimplePlugin.Plugin1.API.Test
{
    public static class StartUp
    {
        public static int? Priority { get; } = 3;

        public static IApplicationBuilder Configure(this IApplicationBuilder app)
        {
            app.UseMiddleware<Plugin1Test1Middleware>();
            app.UseMiddleware<Plugin1Test2Middleware>();
            return app;
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IPlugin1Service, Plugin1Service>();
        }
    }
}
