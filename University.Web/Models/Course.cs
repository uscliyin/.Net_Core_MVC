using System.ComponentModel.DataAnnotations;

namespace University.Web.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get;set; }
        public string CourseDescription { get;set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
