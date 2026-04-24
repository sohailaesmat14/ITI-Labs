using Microsoft.AspNetCore.Mvc;
using WebApiLab3.Models;
using WebApiLab3.Repositories; 

namespace WebApiLab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    /// <summary>
    /// Controller for managing students.
    /// </summary>
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        /// <summary>
        ///     
        /// </summary>
        /// <param name="unitOfWork"></param>
        public StudentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>A list of all students.</returns>
        public async Task<IActionResult> GetStudents()
        {
            var students = await _unitOfWork.Students.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id}")]
        /// <summary>
        /// Gets a student by ID.
        /// </summary>
        /// <param name="id">The ID of the student to retrieve.</param>
        /// <returns>The student with the specified ID.</returns>
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _unitOfWork.Students.GetByIdAsync(id);

            if (student == null)
                return NotFound("student not found");

            return Ok(student);
        }

        [HttpPost]
        /// <summary>
        /// Adds a new student.
        /// </summary>
        /// <param name="student">The student to add.</param>
        /// <returns>A response indicating the result of the operation.</returns>
        public async Task<IActionResult> PostStudent(Student student)
        {
            await _unitOfWork.Students.AddAsync(student);

            await _unitOfWork.SaveAsync();

            return Ok("student added successfully");
        }
    }
}