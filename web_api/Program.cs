using Repositories;
using Services;

namespace web_api
{ 
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped<IUserRepository,UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            //Is IPasswordService registered? UsersController takes it, so the app can not create the controller without this line
            //builder.Services.AddScoped<IPasswordService, PasswordService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
