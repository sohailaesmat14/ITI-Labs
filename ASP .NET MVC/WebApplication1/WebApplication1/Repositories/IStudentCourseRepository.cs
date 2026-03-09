using System.Collections.Generic;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IStudentCourseRepository
    {
        IEnumerable<StudentCourse> GetAllWithDetails();
        void Add(StudentCourse studentCourse);
        bool Exists(int studentId, int courseId);
    }
}