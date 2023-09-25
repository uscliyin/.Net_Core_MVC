using System.ComponentModel.DataAnnotations;

namespace University.Web.Models.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        [MaxLength(255)]
        public string CourseDescription { get; set; }
    }
}
