

using AspNetCore.IServiceCollection.AddIUrlHelper;
using FLASK_COFFEE_API.Infrastructure.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using FLASK_COFFEE_API.Extensions;
namespace FLASK_COFFEE_API.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
  
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(o =>
            {
                o.Cookie.Name = "Identity";
                o.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                o.LoginPath = "/auth/login";
                o.AccessDeniedPath = "/admin/auth/login";
            });
        services.AddAutoMapper(typeof(Program));
        services.AddHttpContextAccessor();

        services.AddUrlHelper();
        services.AddSignalR();
        services.Configure<ApiBehaviorOptions>(o =>
        {
            o.InvalidModelStateResponseFactory =
            (ac) => new BadRequestObjectResult(new { Errors = ac.ModelState.GenerateCustomErrorModel() });
        });
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.ConfigureDatabase(configuration);

        services.ConfigureOptions(configuration);

        services.ConfigureFluentValidatios(configuration);

        services.RegisterCustomServices(configuration);

    }
}
