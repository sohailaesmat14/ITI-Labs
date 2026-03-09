using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class StudentCourseController : Controller
    {
        private readonly IStudentCourseRepository _studentCourseRepo;
        private readonly IStudentRepository _studentRepo;
        private readonly ICourseRepository _courseRepo;

        public StudentCourseController(
            IStudentCourseRepository studentCourseRepo,
            IStudentRepository studentRepo,
            ICourseRepository courseRepo)
        {
            _studentCourseRepo = studentCourseRepo;
            _studentRepo = studentRepo;
            _courseRepo = courseRepo;
        }

        public IActionResult Index()
        {
            var grades = _studentCourseRepo.GetAllWithDetails();
            return View(grades);
        }

        public IActionResult Create()
        {
            ViewBag.Students = new SelectList(_studentRepo.GetAll(), "Id", "Name");
            ViewBag.Courses = new SelectList(_courseRepo.GetAll(), "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentCourse studentCourse)
        {
            ModelState.Remove("Student");
            ModelState.Remove("Course");

            if (ModelState.IsValid)
            {
                if (_studentCourseRepo.Exists(studentCourse.StudentId, studentCourse.CourseId))
                {
                    ModelState.AddModelError("", "This student already has a grade for this course!");
                }
                else
                {
                    _studentCourseRepo.Add(studentCourse);
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.Students = new SelectList(_studentRepo.GetAll(), "Id", "Name", studentCourse.StudentId);
            ViewBag.Courses = new SelectList(_courseRepo.GetAll(), "Id", "Title", studentCourse.CourseId);
            return View(studentCourse);
        }
    }
}