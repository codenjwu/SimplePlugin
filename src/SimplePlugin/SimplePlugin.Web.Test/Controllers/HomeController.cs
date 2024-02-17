using Microsoft.AspNetCore.Mvc;
using SimplePlugin.Common.Test;

namespace SimplePlugin.Web.Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        readonly ICommonService _commonService;
        readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ICommonService commonService)
        {
            _logger = logger;
            _commonService = commonService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"Home Controller:{Environment.NewLine} {_commonService.Text}");
        }
    }
}
