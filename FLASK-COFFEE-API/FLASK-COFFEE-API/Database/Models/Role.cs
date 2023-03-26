using FLASK_COFFEE_API.Database.Models.Common;

namespace FLASK_COFFEE_API.Database.Models
{
    public class Role : BaseEntity<int>, IAuditable
    {
        public string Name { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<User>? Users { get; set; }
        public List<FeedBack>? FeedBacks { get; set; }
    }
}
