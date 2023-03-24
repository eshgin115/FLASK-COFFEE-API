using FLASK_COFFEE_API.Services.Concretes;
using FLASK_COFFEE_API.Services.Services;

namespace FLASK_COFFEE_API.Infrastructure.Configurations
{
    public static class RegisterCustomServicesConfigurations
    {
        public static void RegisterCustomServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IFileService, FileService>();

            //services.AddScoped<IEmailService, SMTPService>();
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IBasketService, BasketService>();
            //services.AddSingleton<IFileService, FileService>();
            //services.AddScoped<INotificationService, NotificationService>();
            //services.AddScoped<IFoodService, FoodService>();
            //services.AddScoped<IDrinkService, DrinkService>();
            //services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IUserActivationService, UserActivationService>();
            //services.AddScoped<IsAuthenticated>();
        }
    }
}
