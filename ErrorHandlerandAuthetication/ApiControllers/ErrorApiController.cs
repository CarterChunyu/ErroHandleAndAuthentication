using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandlerandAuthetication.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorApiController : ControllerBase
    {
        [HttpGet("Error1")]
        public IActionResult Error()
        {
            throw new Exception("拋出異常");
            return Ok();
        }
    }
}
