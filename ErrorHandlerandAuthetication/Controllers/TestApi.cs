using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlerandAuthetication.Controllers
{
    [Authorize(Policy = "MenuPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestApi : ControllerBase
    {
        [HttpGet("Index1")]
        public IActionResult Index1()
        {
            return Ok("Index1");
        }
    }
}
