using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly ItiDbContext _context;

        public StudentCourseRepository(ItiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<StudentCourse> GetAllWithDetails()
        {
            return _context.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .ToList();
        }

        public void Add(StudentCourse studentCourse)
        {
            _context.StudentCourses.Add(studentCourse);
            _context.SaveChanges();
        }

        public bool Exists(int studentId, int courseId)
        {
            return _context.StudentCourses.Any(sc => sc.StudentId == studentId && sc.CourseId == courseId);
        }
    }
}