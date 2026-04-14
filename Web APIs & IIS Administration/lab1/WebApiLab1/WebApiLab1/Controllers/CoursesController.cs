using Microsoft.AspNetCore.Mvc;
using WebApiLab1.Models;

namespace WebApiLab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult get()
        {
            var courses = _context.Courses.ToList();

            if (courses.Count == 0)
                return NotFound("No courses found.");

            return Ok(courses);
        }

        [HttpGet("{id:int}")]
        public IActionResult getById(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.ID == id);

            if (course == null)
                return NotFound($"Course with ID {id} not found.");

            return Ok(course);
        }

        [HttpGet("name/{name}")]
        public IActionResult couseByName(string name)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Crs_name == name);

            if (course == null)
                return NotFound($"Course with name {name} not found.");

            return Ok(course);
        }

        [HttpPost]
        public IActionResult post([FromBody] Course course)
        {
            if (course == null)
                return BadRequest("Course data cannot be null.");

            _context.Courses.Add(course);
            _context.SaveChanges();

            return StatusCode(201, course);
        }

        [HttpPut("{id}")]
        public IActionResult put(int id, [FromBody] Course course)
        {
            if (course == null || id != course.ID)
                return BadRequest("Course ID mismatch.");

            var existingCourse = _context.Courses.FirstOrDefault(c => c.ID == id);

            if (existingCourse == null)
                return NotFound($"Course with ID {id} not found.");

            existingCourse.Crs_name = course.Crs_name;
            existingCourse.crs_desc = course.crs_desc;
            existingCourse.Duration = course.Duration;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult deleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.ID == id);

            if (course == null)
                return NotFound($"Course with ID {id} not found.");

            _context.Courses.Remove(course);
            _context.SaveChanges();

            return Ok(_context.Courses.ToList());
        }
    }
}