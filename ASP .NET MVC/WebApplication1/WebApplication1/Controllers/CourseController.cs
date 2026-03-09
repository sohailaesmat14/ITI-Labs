using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IDepartmentRepository _departmentRepo;

        public CourseController(ICourseRepository courseRepo, IDepartmentRepository departmentRepo)
        {
            _courseRepo = courseRepo;
            _departmentRepo = departmentRepo;
        }

        public IActionResult Index()
        {
            return View(_courseRepo.GetAll());
        }

        public IActionResult Details(int id)
        {
            var course = _courseRepo.GetById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_departmentRepo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            ModelState.Remove("Department");
            ModelState.Remove("StudentCourses");

            if (ModelState.IsValid)
            {
                _courseRepo.Add(course);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_departmentRepo.GetAll(), "Id", "Name", course.DepartmentId);
            return View(course);
        }

        public IActionResult Edit(int id)
        {
            var course = _courseRepo.GetById(id);
            if (course == null) return NotFound();

            ViewBag.Departments = new SelectList(_departmentRepo.GetAll(), "Id", "Name", course.DepartmentId);
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
            ModelState.Remove("Department");
            ModelState.Remove("StudentCourses");

            if (ModelState.IsValid)
            {
                _courseRepo.Update(course);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_departmentRepo.GetAll(), "Id", "Name", course.DepartmentId);
            return View(course);
        }

        public IActionResult Delete(int id)
        {
            var course = _courseRepo.GetById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _courseRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}