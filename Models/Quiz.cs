namespace Coursify.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Level Level { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<UserQuiz> UserQuizzes { get; set; } = new List<UserQuiz>();

    }

    public enum Level
    {
        Basic,
        Medium,
        Advanced
    }

}
