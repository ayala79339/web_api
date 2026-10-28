using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace web_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //In C#, class names are written in PascalCase: UsersController
    public class usersController : ControllerBase
    {

        [HttpPut("{id}")]
        //fix: The id is part of the route ({id}), not the query string, so [FromQuery] is removed.
        //With [FromQuery], PUT /users/5 got id = 0 and updated the wrong user
        public ActionResult<Users> Put(int id,[FromBody] Users userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =System.IO.File.OpenText(FilePath))

            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users curruser =JsonSerializer.Deserialize<Users>(currentUserInFile);

                    if (curruser.Id == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if (textToReplace != string.Empty)
            {
                //fix: Keep the id, otherwise the updated user is saved without it
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
                        //fix: GET only reads, so it returns 200 Ok and not 201 Created
                        return Ok(user);
                }
            }
            return NotFound();
        }

        //fix: The path never changes, so it can be readonly
        readonly string FilePath = "Users.txt";
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
