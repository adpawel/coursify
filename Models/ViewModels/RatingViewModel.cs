using System.ComponentModel.DataAnnotations;

namespace Coursify.Models.ViewModels
{
    public class RatingViewModel
    {
        public int Id { get; set; }
        [Required]
        [Range(1, 5)]
        public int Stars { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}

