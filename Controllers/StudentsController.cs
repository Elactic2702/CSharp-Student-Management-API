using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSharp_Student_Management_API.Data;
using CSharp_Student_Management_API.Models;

namespace CSharp_Student_Management_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public StudentsController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: api/students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();

            return Ok(students);
        }

        // GET: api/students/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "Student not found"
                });
            }

            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            _context.Students.Add(student);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetStudent),
                new { id = student.Id },
                student
            );
        }

        // PUT: api/students/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(
            int id,
            Student updatedStudent)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "Student not found"
                });
            }

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Course = updatedStudent.Course;
            student.Email = updatedStudent.Email;

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Student updated successfully",
                student
            });
        }

        // DELETE: api/students/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = "Student not found"
                });
            }

            _context.Students.Remove(student);

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Student deleted successfully"
            });
        }
    }
}