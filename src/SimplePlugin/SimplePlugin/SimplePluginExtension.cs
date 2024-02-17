using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SimplePlugin
{
    public static class SimplePluginExtension
    {
        public static IMvcBuilder ConfigSimplePlugin(this IMvcBuilder builder, string pluginPath)
        {
            ArgumentNullException.ThrowIfNull(pluginPath);
            SimplePluginOptions.PluginPath = pluginPath;
            AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;

            foreach (string dll in Directory.GetFiles(SimplePluginOptions.PluginPath, "*.dll"))
            {
                var assembly = Assembly.LoadFile(dll);
                SimplePluginOptions.PluginAssemblies.Add(assembly.FullName, assembly);
            }

            foreach (var asm in SimplePluginOptions.PluginAssemblies)
                builder.PartManager.ApplicationParts.Add(new AssemblyPart(asm.Value));

            // add IServiceConfiguration
            foreach (var asm in SimplePluginOptions.PluginAssemblies)
                foreach (MethodInfo method in SimplePluginOptions.GetExtensionMethods(asm.Value,typeof(IServiceCollection)))
                {
                    method
                        .Invoke(null, new object[] { builder.Services });  
                }
            return builder;
        }
        static Assembly ResolveAssembly(Object sender, ResolveEventArgs e)
        {
            SimplePluginOptions.PluginAssemblies.TryGetValue(e.Name, out Assembly res);
            return res;
        }
    }
}
