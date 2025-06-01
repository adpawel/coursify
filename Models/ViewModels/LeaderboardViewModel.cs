namespace Coursify.Models.ViewModels
{
    public class LeaderboardViewModel
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int QuizCount { get; set; }
        public int Rank { get; set; }
    }
}
