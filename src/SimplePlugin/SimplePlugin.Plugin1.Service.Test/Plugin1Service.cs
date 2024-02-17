using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlugin.Plugin1.Service.Test
{
    public class Plugin1Service : IPlugin1Service
    {
        public string Text { get; } = "From Plugin1Service";
    }
    public interface IPlugin1Service
    {
        string Text { get; }
    }
}
