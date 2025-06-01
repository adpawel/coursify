using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Coursify.Models.ViewModels
{
    public class QuizCreateViewModel
    {
        [Required]
        [Display(Name = "Quiz Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Level")]
        public Level Level { get; set; }

        [Required]
        [Display(Name = "Course")]
        public int CourseId { get; set; }

        public IEnumerable<SelectListItem>? Courses { get; set; }
        public IEnumerable<SelectListItem>? Levels { get; set; }
    }

}
