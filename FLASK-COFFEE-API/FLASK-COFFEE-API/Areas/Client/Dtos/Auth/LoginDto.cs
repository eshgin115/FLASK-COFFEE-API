namespace FLASK_COFFEE_API.Areas.Client.Dtos.Auth
{
    public class LoginDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
