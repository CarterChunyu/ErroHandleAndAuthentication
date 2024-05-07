using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlerandAuthetication.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;   
        }

        public IActionResult Index()
        {
            _logger.LogInformation("嗨嗨");
            throw new Exception("拋出異常");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
