using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entities;
namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id,[FromBody] User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =System.IO.File.OpenText(FilePath))

            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User curruser =JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (curruser.Id == id)
                    {
                        textToReplace = currentUserInFile;
                        break;
                    }
                       
                }
            }
            if (textToReplace != string.Empty)
            {
                userToUpdate.Id = id;
                string text = System.IO.File.ReadAllText(FilePath);
                text = text.Replace(textToReplace,JsonSerializer.Serialize(userToUpdate));

                System.IO.File.WriteAllText(FilePath, text);
            }
            return Ok(userToUpdate);

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
        public ActionResult<User> Get(int id )
        { 
           using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return Ok(user);
                }
            }
            return NotFound();
        }

        readonly string FilePath = "Users.txt";
        [HttpPost("loguppost")]
        public ActionResult<User> Post([FromBody] User user)
        {

            int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(FilePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        [HttpPost("loginpost")]
        public ActionResult<User> Post([FromBody] UserLog userLog)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))

            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user = JsonSerializer.Deserialize<User>(currentUserInFile);

                    if (user.Email == userLog.Email && user.Password == userLog.Password)

                        return Ok(user);
                }
            }
            return null;
        }
    } 
     
    }
