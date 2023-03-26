using FLASK_COFFEE_API.Database.Models;

namespace FLASK_COFFEE_API.Services.Concretes;

public interface IUserActivationService
{
    Task SendActivationUrlAsync(User user);
}