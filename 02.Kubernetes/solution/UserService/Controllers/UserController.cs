using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UserService.DataAccess.Data;
using UserService.DataAccess.Models;

namespace UserService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private UserContext _ctx;

        public UserController(IConfiguration confifguration)
        {
            var config = confifguration;
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();

            var options = optionsBuilder
                //.UseSqlServer(config.GetConnectionString("UserContext"))
                .UseSqlServer("Server=192.168.99.103,31433;Database=Users;User Id=SA;Password=Admin-123;")
                .Options;
            
            _ctx = new UserContext(options);
        }
        
        // GET
        [HttpGet]
        [Route("/user")]
        public IActionResult GetUsers()
        {
            var users = _ctx.Users.ToListAsync().Result;

            if (users == null)
            {
                return NotFound($"No users found.");
            }
                
            return Ok(users);
        }
        
        // GET
        [HttpGet]
        [Route("/user/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _ctx.Users.FirstOrDefaultAsync(x => x.Id == id).Result;

            if (user == null)
            {
                return NotFound($"User with id='{id}' not found.");
            }
                
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(User user)
        {
            var addedUser = _ctx.Users.Add(user);
            _ctx.SaveChanges();
            
            return Ok(addedUser.Entity);
        }
        
        [HttpDelete]
        [Route("/user/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _ctx.Users.FirstOrDefaultAsync(x => x.Id == id).Result;

            if (user == null)
            {
                return NotFound($"User with id='{id}' not found.");
            }

            _ctx.Users.Remove(user);
            _ctx.SaveChanges();
                
            return NotFound($"User with id='{id}' was deleted.");
        }
        
        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            var obj = _ctx.Users.FirstOrDefaultAsync(x => x.Id == user.Id).Result;

            if (obj == null)
            {
                return NotFound($"User with id='{user.Id}' not found.");
            }

            obj.FirstName = user.FirstName;
            obj.LastName = user.LastName;
            obj.Email = user.Email;
            
            _ctx.SaveChanges();
            
            return Ok($"User with id='{user.Id}' was successfully updated.");
        }
    }
}