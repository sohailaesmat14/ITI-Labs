using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        [Range(0, 100, ErrorMessage = "Grades should between 0 to 100")]
        public decimal Degree { get; set; }
    }
}