using Microsoft.AspNetCore.Mvc;
using Prova.MarQ.Domain.Entities;
using Prova.MarQ.Infra;
using System.Threading.Tasks;

namespace Prova.MarQ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly ProvaMarqDbContext _context;

        public EmployeeController(ProvaMarqDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (employee.PIN.Length > 4)
            {
                ModelState.AddModelError("Must be less than 4 characters");
                return BadRequest(ModelState);
            }

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
    }
}