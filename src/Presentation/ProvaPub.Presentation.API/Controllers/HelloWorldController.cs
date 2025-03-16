using Microsoft.AspNetCore.Mvc;

namespace ProvaPub.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet("hello")]

        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public ActionResult Hello() => Ok("Hello World!");
    }
}
