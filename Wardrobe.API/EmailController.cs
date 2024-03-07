using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Wardrobe.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public IActionResult GetTest()
        {
            return Ok();
        }
    }
}
