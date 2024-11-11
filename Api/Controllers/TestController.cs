
using Microsoft.AspNetCore.Mvc;
using Oebm_Producer.Context;

namespace Oebm_Producer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("send")]
        public IActionResult Gett(string message)
        {
            var context = new AppAMQPContext();
            context.Sender("test", "");

            return Ok();
        }
    }
}
