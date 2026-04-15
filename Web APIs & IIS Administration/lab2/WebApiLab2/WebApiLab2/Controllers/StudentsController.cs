using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebApiLab2.Models;
using WebApiLab2.DTOs;

namespace WebApiLab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class StudentsController : ControllerBase
    {
        private readonly ItiContext _context;
        private readonly IMapper _mapper;

        public StudentsController(ItiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStudents([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string? search = null)
        {
            var query = _context.Students
                .Include(s => s.Dept)
                .Include(s => s.StSuperNavigation)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(s => s.StFname.Contains(search) || s.StLname.Contains(search));
            }

            var students = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var studentsDto = _mapper.Map<List<StudentDTO>>(students);
            return Ok(studentsDto);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest("Data is missing");

            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok("Student added successfully");
        }
        
    }
}