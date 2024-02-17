using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlugin.Plugin2.Service.Test
{
    public class Plugin2Service : IPlugin2Service
    {
        public string Text { get; } = "From Plugin2Service";
    }
    public interface IPlugin2Service
    {
        string Text { get; }
    }
}
