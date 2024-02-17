# SimplePlugin

SimplePlugin is a C# library for creating decoupled plugin system for your web project.

## Usage

A) Configuring Plugin folder in your main web project
```csharp
var mvcbuilder = builder.Services.AddControllers();
mvcbuilder.ConfigSimplePlugin(@"your plugin folder path");
```
B) Adding services: 
create extension method in your plugin project, must extend IServiceCollection:
```csharp
public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<IPlugin1Service, Plugin1Service>();
    }
```
C)Add Middleware:
1-> create extension method in your plugin project, must extend IApplicationBuilder.
    set Priority accordingly, otherwise the middleware will be random ordered.
```csharp
    public static int? Priority { get; } = 3;

    public static IApplicationBuilder Configure(this IApplicationBuilder app)
        {
            app.UseMiddleware<Plugin1Test1Middleware>();
            app.UseMiddleware<Plugin1Test2Middleware>();
            return app;
        }
```
2-> Call SimplePluginMiddelwareBuilder.Use method and pass specified assembly or list of assemblies.
```csharp
// add single assembly
//SimplePluginMiddelwareBuilder.Use(app, SimplePluginOptions.PluginAssemblies.First().Value);
//add multiple assembly
SimplePluginMiddelwareBuilder.Use(app, SimplePluginOptions.PluginAssemblies.Select(x => x.Value));
```

D) build your plugin project and copy dll to your plugin folder.
E) start your application!