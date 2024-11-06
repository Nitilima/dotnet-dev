using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Prova.MarQ.Infra;
using Prova.MarQ.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.MarQ.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ProvaMarqDbContext _context;

        public CompanyController(ProvaMarqDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCompany([FromBody] Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompany), new { id = company.Id }, company);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompany(Guid id)
        {
            var company = await _context.Companies.FindAsync(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }
    }
}
