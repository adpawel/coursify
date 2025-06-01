using Coursify.Areas.Identity.Data;

namespace Coursify.Models
{
    public class UserCourse
    {
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public DateTime EnrolledAt { get; set; }
    }
}
