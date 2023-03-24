using System.ComponentModel.DataAnnotations;

namespace FLASK_COFFEE_API.Areas.Admin.Dtos.FeedBack;

public class FeedBackCreateDto
{
    public IFormFile ProfilePhoto { get; set; } = default!;

    [Required]
    public string Name { get; set; } = default!;


    [Required]
    public string Content { get; set; } = default!;

    public int RoleId { get; set; }
   
}
