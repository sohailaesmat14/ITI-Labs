using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public IActionResult Index()
        {
            return View(_studentRepo.GetAll());
        }

        public IActionResult Details(int id)
        {
            var student = _studentRepo.GetStudentWithDetails(id);
            if (student == null) return NotFound();
            return View(student);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            ModelState.Remove("Department");
            ModelState.Remove("StudentCourses");
            if (ModelState.IsValid)
            {
                _studentRepo.Add(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = _studentRepo.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            ModelState.Remove("Department");
            ModelState.Remove("StudentCourses");
            if (ModelState.IsValid)
            {
                _studentRepo.Update(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _studentRepo.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _studentRepo.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
