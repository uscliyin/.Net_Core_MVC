﻿namespace University.Web.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }=DateTime.Now;
        

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
