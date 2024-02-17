using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlugin
{
    public class SimplePluginAssemblyMiddelware
    {
        readonly RequestDelegate _next;
        readonly Assembly _assembly;
        readonly IApplicationBuilder _app;
        private SimplePluginAssemblyMiddelware(RequestDelegate next, IApplicationBuilder app) { _next = next; _app = app; }
        public SimplePluginAssemblyMiddelware(RequestDelegate next, IApplicationBuilder app, Assembly assembly) : this(next, app)
        {
            _assembly = assembly;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            foreach (var method in SimplePluginOptions.GetExtensionMethods(_assembly, typeof(IApplicationBuilder)))
            {
                method
                    .Invoke(null, new object[] { _app });
            }

            await _next(context);
        }
    }
    public class SimplePluginAssembliesMiddelware
    {
        readonly RequestDelegate _next;
        readonly IEnumerable<Assembly> _assemblies;
        readonly IApplicationBuilder _app;
        private SimplePluginAssembliesMiddelware(RequestDelegate next, IApplicationBuilder app) { _next = next; _app = app; }

        public SimplePluginAssembliesMiddelware(RequestDelegate next, IApplicationBuilder app, IEnumerable<Assembly> assemblies) : this(next, app)
        {
            _assemblies = assemblies;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (_assemblies.Any())
            {
                foreach (var assembly in _assemblies)
                    foreach (var method in SimplePluginOptions.GetExtensionMethods(assembly, typeof(IApplicationBuilder)).OrderByDescending(x => (int.TryParse((x.DeclaringType?.GetProperty("Priority")?.GetValue(null)?.ToString() ?? "-1"), out int order) ? order : -1)))
                    {
                        method
                            .Invoke(null, new object[] { _app });
                    }
            }
            else
            {
                throw new DllNotFoundException();
            }
            await _next(context);
        }
    }
    public static class SimplePluginMiddelwareBuilder
    {
        public static void Use(
              IApplicationBuilder builder, Assembly assembly)
        {
            foreach (var method in SimplePluginOptions.GetExtensionMethods(assembly, typeof(IApplicationBuilder)))
            {
                method
                    .Invoke(null, new object[] { builder });
            }
        }
        public static void Use(
              IApplicationBuilder builder, IEnumerable<Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
                foreach (var method in SimplePluginOptions.GetExtensionMethods(assembly, typeof(IApplicationBuilder)).OrderByDescending(x => (int.TryParse((x.DeclaringType?.GetProperty("Priority")?.GetValue(null)?.ToString() ?? "-1"), out int order) ? order : -1)))
                {
                    method
                        .Invoke(null, new object[] { builder });
                }
        }
    }
}
