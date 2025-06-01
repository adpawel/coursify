namespace Coursify.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public Comment Comment { get; set; } = new Comment();
        public int Stars { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
