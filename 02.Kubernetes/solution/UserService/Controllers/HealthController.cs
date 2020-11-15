using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : Controller
    {
        private IConfiguration _config;

        public HealthController(IConfiguration confifguration)
        {
            _config = confifguration;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return StatusCode(200, new Response { Status = "OK", Connection = _config.GetConnectionString("UserContext")});
        }
        
        private new class Response
        {
            public string Status { get; set; }
            public string Connection { get; set; }
        }
    }
}