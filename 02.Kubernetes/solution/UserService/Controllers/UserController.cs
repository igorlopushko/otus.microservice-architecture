using Microsoft.AspNetCore.Mvc;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        // GET
        [HttpGet]
        public IActionResult GetUser(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateUser()
        {
            return View();
        }
        
        [HttpDelete]
        public IActionResult DeleteUser()
        {
            return View();
        }
        
        [HttpPut]
        public IActionResult UpdateUser()
        {
            return View();
        }
    }
}