using Coursify.Areas.Identity.Data;

namespace Coursify.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int RatingId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public Rating Rating { get; set; }

    }
}
