using Microsoft.AspNetCore.Mvc;
using SimplePlugin.Common.Test;
using SimplePlugin.Plugin2.Service.Test;

namespace SimplePlugin.Plugin2.API.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Plugin2Controller : ControllerBase
    {

        readonly IPlugin2Service _plugin2Service;
        readonly ICommonService _commonService;
        readonly ILogger<Plugin2Controller> _logger;

        public Plugin2Controller(ILogger<Plugin2Controller> logger, IPlugin2Service plugin1Service, ICommonService commonService)
        {
            _logger = logger;
            _plugin2Service = plugin1Service;
            _commonService = commonService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"Plugin1 Controller:{Environment.NewLine} {_plugin2Service.Text} {Environment.NewLine} {_commonService.Text}");
        }
    }
}
