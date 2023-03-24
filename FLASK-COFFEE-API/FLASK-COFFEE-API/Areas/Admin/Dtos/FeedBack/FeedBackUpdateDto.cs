namespace FLASK_COFFEE_API.Areas.Admin.Dtos.FeedBack;

public class FeedBackUpdateDto
{
    public string? ProfilePhotoUrl { get; set; } = null!;

    public IFormFile? ProfilePhoto { get; set; } = null!;

    public string? Name { get; set; }


    public string? Content { get; set; }

    public int? RoleId { get; set; }
}
