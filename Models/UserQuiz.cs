using Coursify.Areas.Identity.Data;

namespace Coursify.Models
{
    public class UserQuiz
    {
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; } = null!;
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
        public int? Score { get; set; }
        }
}
