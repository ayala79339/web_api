using Microsoft.AspNetCore.Mvc; 
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
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            await _userService.UpdateUser(id,userToUpdate);           
        }

  

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id )
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
                return NotFound();
            return Ok(user);   
        }

        
        [HttpPost("loguppost")]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {   int strengh = _passwordService.GetStrength(user.Password);
            if (strengh < 1)
            {
                return BadRequest("Password is too weak");
            }
            var addedUser = await _userService.AddUser(user);
         
            return CreatedAtAction(nameof(Get), new { id = addedUser.Id }, addedUser);
        }

        [HttpPost("loginpost")]
        public async Task<ActionResult<User>> Post([FromBody] UserLog userLog)
        {
            var user = await _userService.Login(userLog);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
    } 
     
    }
