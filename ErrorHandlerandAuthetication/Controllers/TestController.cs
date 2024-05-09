using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlerandAuthetication.Controllers
{
    [Authorize(Policy = "MenuPolicy")]
    public class TestController : Controller
    {
        
        public IActionResult Index1()
        {
            return View();
        }
    }
}
