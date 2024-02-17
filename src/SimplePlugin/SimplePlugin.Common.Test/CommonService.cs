using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePlugin.Common.Test
{
    public class CommonService : ICommonService
    {
        public string Text { get; } = "From CommonService";
    }
    public interface ICommonService
    {
        string Text { get; }
    }
}
