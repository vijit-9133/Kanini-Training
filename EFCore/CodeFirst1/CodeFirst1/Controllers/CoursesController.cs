using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodeFirst1.Data;
using CodeFirst1.Models;

namespace CodeFirst1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly StudDeptContext _context;

        public CoursesController(StudDeptContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses
                .Include(c => c.StudentCourses)
                    .ThenInclude(sc => sc.Student)
                .Include(c => c.CourseTrainers)
                    .ThenInclude(ct => ct.Trainer)
                .ToListAsync();
        }

        // GET: api/Courses/101
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _context.Courses
                .Include(c => c.StudentCourses)
                    .ThenInclude(sc => sc.Student)
                .Include(c => c.CourseTrainers)
                    .ThenInclude(ct => ct.Trainer)
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }

        // PUT: api/Courses/101
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {
            if (id != course.CourseId)
            {
                return BadRequest();
            }

            // 1. Find the existing course with its current relationships
            var existingCourse = await _context.Courses
                .Include(c => c.StudentCourses)
                .Include(c => c.CourseTrainers)
                .FirstOrDefaultAsync(c => c.CourseId == id);

            if (existingCourse == null)
            {
                return NotFound();
            }

            // 2. Update simple properties (like CourseName)
            _context.Entry(existingCourse).CurrentValues.SetValues(course);

            // 3. Manage the many-to-many relationships

            // Update Student-Course relationship
            existingCourse.StudentCourses.Clear();
            foreach (var studentLink in course.StudentCourses)
            {
                _context.StudentCourses.Add(new StudentCourse { CourseId = existingCourse.CourseId, StudentId = studentLink.StudentId });
            }

            // Update Course-Trainer relationship
            existingCourse.CourseTrainers.Clear();
            foreach (var trainerLink in course.CourseTrainers)
            {
                _context.CourseTrainers.Add(new CourseTrainer { CourseId = existingCourse.CourseId, TrainerId = trainerLink.TrainerId });
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Courses
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.CourseId }, course);
        }

        // DELETE: api/Courses/101
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
