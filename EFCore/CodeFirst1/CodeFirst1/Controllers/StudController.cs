using CodeFirst1.Data;
using CodeFirst1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq; // Added for .Any() method

namespace CodeFirst1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudController : ControllerBase
    {
        private readonly StudDeptContext _context;

        public StudController(StudDeptContext context)
        {
            _context = context;
        }

        // GET: api/Stud
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetAll()
        {
            return await _context.Students
                .Include(s => s.Department)
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .ToListAsync();
        }

        // GET: api/Stud/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            Student? s = await _context.Students
                .Include(s => s.Department)
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(s => s.StudentId == id);

            return s == null ? NotFound() : Ok(s);
        }

        // GET: api/Stud/Virendra
        [HttpGet("{name}")]
        public async Task<ActionResult<Student>> GetByName(string name)
        {
            Student? s = await _context.Students
                .Include(s => s.Department)
                .Include(s => s.StudentCourses)
                    .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(s => s.Name == name);

            return s == null ? NotFound() : Ok(s);
        }

        // POST: api/Stud
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student stud)
        {
            await _context.Students.AddAsync(stud);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = stud.StudentId }, stud);
        }

        // PUT: api/Stud/5
        [HttpPut("{id}")]
        public async Task<ActionResult> EditStudent(int id, Student ustud)
        {
            if (id != ustud.StudentId)
            {
                return BadRequest("ID in URL must match ID in body.");
            }

            _context.Entry(ustud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Students.Any(e => e.StudentId == id))
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

        // DELETE: api/Stud/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            Student? stud = await _context.Students.FindAsync(id);
            if (stud is null)
            {
                return NotFound();
            }

            _context.Students.Remove(stud);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}