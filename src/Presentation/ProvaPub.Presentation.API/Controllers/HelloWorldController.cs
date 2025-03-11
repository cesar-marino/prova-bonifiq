using Microsoft.AspNetCore.Mvc;

namespace ProvaPub.Presentation.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        [HttpGet]
        public ActionResult Hello() => Ok("Hello World!");
    }
}
