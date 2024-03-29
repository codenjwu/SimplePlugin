﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlugin
{
    public class SimplePluginOptions
    {
        public static string PluginPath { get; set; }

        public static readonly IDictionary<string, Assembly> PluginAssemblies = new Dictionary<string, Assembly>();

        internal static IEnumerable<MethodInfo> GetExtensionMethods(Assembly assembly, Type targetType)
        {
            return from type in assembly.GetTypes()
                   where !type.IsGenericType && !type.IsNested
                   from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                   where method.IsDefined(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false)
                   where method.GetParameters()[0].ParameterType == targetType
                   select method;
        }
    }
}
