namespace Coursify.Models.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int RatingId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Stars { get; set; }
        public int CourseId { get; set; }
    }
}
