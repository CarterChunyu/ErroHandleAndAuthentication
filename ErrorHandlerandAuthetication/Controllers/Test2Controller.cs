using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlerandAuthetication.Controllers
{
    [Authorize(Policy = "MenuPolicy")]
    public class Test2Controller : Controller
    {
        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }
    }
}
