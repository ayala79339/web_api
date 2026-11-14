using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entities;
using Services;
namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPasswordService _passwordService;

        public UsersController(IUserService userService, IPasswordService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id,[FromBody] User userToUpdate)
        {
            //fix: the id from the URL is set on the user, so the right user is updated
            userToUpdate.Id = id;
            User user = _userService.UpdateUser(userToUpdate);         

            return Ok(user);
        }

  

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id )
        {
            User user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);    

        }

        
        [HttpPost("loguppost")]
        public ActionResult<User> Post([FromBody] User user)
        {   int strengh = _passwordService.GetStrength(user.Password);
            if (strengh < 3)
            {
                return BadRequest("Password is too weak");
            }
            var addedUser = _userService.AddUser(user);
         
            return CreatedAtAction(nameof(Get), new { id = addedUser.Id }, addedUser);
        }

        //The assignment asks login with a wrong password to return 204: what does this return when the login fails?
        [HttpPost("loginpost")]
        public ActionResult<User> Post([FromBody] UserLog userLog)
        {
            var user = _userService.Login(userLog);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
    } 
     
    }
