using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

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
            throw new Exception("Error");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string? errMessage)
        {
            if (!string.IsNullOrEmpty(errMessage))
            {
                //Tuple<string>? message = JsonConvert.DeserializeObject<Tuple<string>>(errMessage);
                ViewBag.ErrMessage = JsonConvert.DeserializeObject<string>(errMessage);
            }
            return View();
        }
    }
}
