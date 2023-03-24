using FLASK_COFFEE_API.Database.Models.Common;

namespace FLASK_COFFEE_API.Database.Models
{
    public class FeedBack : BaseEntity<int>, IAuditable
    {
        public string Name { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string? ImageName { get; set; } = default!;
        public string? ImageNameInFileSystem { get; set; } = default!;
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
