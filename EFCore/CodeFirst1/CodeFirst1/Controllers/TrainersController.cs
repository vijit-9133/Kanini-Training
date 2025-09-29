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
    public class TrainersController : ControllerBase
    {
        private readonly StudDeptContext _context;

        public TrainersController(StudDeptContext context)
        {
            _context = context;
        }

        // GET: api/Trainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trainer>>> GetTrainers()
        {
            return await _context.Trainers
                .Include(t => t.CourseTrainers)
                    .ThenInclude(ct => ct.Course)
                .ToListAsync();
        }

        // GET: api/Trainers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Trainer>> GetTrainer(int id)
        {
            var trainer = await _context.Trainers
                .Include(t => t.CourseTrainers)
                    .ThenInclude(ct => ct.Course)
                .FirstOrDefaultAsync(t => t.TrainerId == id);

            if (trainer == null)
            {
                return NotFound();
            }

            return trainer;
        }

        // PUT: api/Trainers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrainer(int id, Trainer trainer)
        {
            if (id != trainer.TrainerId)
            {
                return BadRequest();
            }

            var existingTrainer = await _context.Trainers
                .Include(t => t.CourseTrainers)
                .FirstOrDefaultAsync(t => t.TrainerId == id);

            if (existingTrainer == null)
            {
                return NotFound();
            }

            // Update simple properties
            _context.Entry(existingTrainer).CurrentValues.SetValues(trainer);

            // Update Course-Trainer relationship
            existingTrainer.CourseTrainers.Clear();
            foreach (var courseLink in trainer.CourseTrainers)
            {
                _context.CourseTrainers.Add(new CourseTrainer
                {
                    TrainerId = existingTrainer.TrainerId,
                    CourseId = courseLink.CourseId
                });
            }

            // Check existence before saving
            if (!TrainerExists(id))
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Trainers
        [HttpPost]
        public async Task<ActionResult<Trainer>> PostTrainer(Trainer trainer)
        {
            _context.Trainers.Add(trainer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrainer", new { id = trainer.TrainerId }, trainer);
        }

        // DELETE: api/Trainers/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var trainer = await _context.Trainers.FindAsync(id);
            if (trainer == null)
            {
                return NotFound();
            }

            _context.Trainers.Remove(trainer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrainerExists(int id)
        {
            return _context.Trainers.Any(e => e.TrainerId == id);
        }
    }
}
