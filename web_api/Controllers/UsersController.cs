using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class usersController : ControllerBase
    {

        [HttpPut("{id}")]
        public ActionResult<Users> Put([FromQuery]int id,[FromBody] Users user)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users userToChange =JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (userToChange.Id == id)
                    {
                        userToChange.Email = user.Email;
                        userToChange.Password = user.Password;
                        userToChange.First_name = user.First_name;
                        userToChange.Last_name = user.Last_name;
                    }
                    return Ok(userToChange);
                }
            }
            return NotFound();

        }


        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id )
        { 
           using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user =
                    JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.Id == id)
                        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
                }
            }
            return NotFound();
        }

        string FilePath = "Users.txt";
        [HttpPost("loguppost")]
        public ActionResult<Users> Post([FromBody] Users user)
        {

            int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(FilePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPost("loginpost")]
        public ActionResult<Users> Post([FromBody] UsersLog usersLog)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))

            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);

                    if (user.Email == usersLog.Email && user.Password == usersLog.Password)

                        return Ok(user);
                }
            }
            return null;
        }
    } 
     
    }
