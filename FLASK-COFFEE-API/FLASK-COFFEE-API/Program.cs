using FLASK_COFFEE_API.Infrastructure.Extensions;

namespace FLASK_COFFEE_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.ConfigureServices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.ConfigureMiddlewarePipeline();

            app.Run();
        }
    }
}