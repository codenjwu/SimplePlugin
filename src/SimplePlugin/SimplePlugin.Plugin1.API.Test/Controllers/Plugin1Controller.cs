using Microsoft.AspNetCore.Mvc;
using SimplePlugin.Common.Test;
using SimplePlugin.Plugin1.Service.Test;
using System.Reflection;

namespace SimplePlugin.Plugin1.API.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Plugin1Controller : ControllerBase
    {

        readonly IPlugin1Service _plugin1Service;
        readonly ICommonService _commonService;
        readonly ILogger<Plugin1Controller> _logger;

        public Plugin1Controller(ILogger<Plugin1Controller> logger,IPlugin1Service plugin1Service,ICommonService commonService)
        {
            _logger = logger;
            _plugin1Service = plugin1Service;
            _commonService = commonService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"Plugin1 Controller:{Environment.NewLine} {_plugin1Service.Text} {Environment.NewLine} {_commonService.Text}");
        }
    }
}
