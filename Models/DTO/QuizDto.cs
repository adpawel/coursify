namespace Coursify.Models.DTO
{
    public class QuizDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Level Level { get; set; }
        public int CourseId { get; set; }
    }
}
