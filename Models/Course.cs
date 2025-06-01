using System.ComponentModel.DataAnnotations;

namespace Coursify.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Category { get; set; }
        public string? Details { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<Rating> Ratings { get; set; } = [];

        public Course()
        {
            UserCourses = new List<UserCourse>();
        }

    }
}
