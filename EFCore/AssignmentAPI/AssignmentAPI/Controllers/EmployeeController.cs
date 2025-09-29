using AssignmentAPI.Data;
using AssignmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AssignmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmpProContext _context;

        // Dependency injection to get the database context
        public EmployeeController(EmpProContext context)
        {
            _context = context;
        }

        // POST: api/employees
        // Add a new employee to a project
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        // GET: api/employees
        // Get all employees with project details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _context.Employees
                .Include(e => e.Project) // Eager load the related Project
                .ToListAsync();
        }

        // GET: api/employees/5
        // Get an employee by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Project) // Eager load the related Project
                .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/employees/5
        // Update employee details
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            // Check if the employee exists before saving changes
            var employeeExists = await _context.Employees.AnyAsync(e => e.EmployeeId == id);
            if (!employeeExists)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/employees/5
        // Remove an employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}