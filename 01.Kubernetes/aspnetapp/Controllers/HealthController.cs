using Microsoft.AspNetCore.Mvc;

namespace aspnetapp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return StatusCode(200, new Response { Status = "OK"});
        }
        
        private class Response
        {
            public string Status { get; set; }
        }
    }
}