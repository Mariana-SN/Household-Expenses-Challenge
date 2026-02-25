using HouseholdExpenses.Domain.Entities;
using HouseholdExpenses.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseholdExpensesAPI.Controllers
{
    /// <summary>
    /// Endpoint para gestão de membros da família.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PersonController(AppDbContext context) => _context = context;

        /// <summary> Lista todas as pessoas cadastradas. </summary>
        [HttpGet]
        public async Task<IActionResult> List() => Ok(await _context.People.ToListAsync());

        /// <summary> Cria um novo registro de pessoa. </summary>
        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }

        /// <summary> Remove uma pessoa e, por cascata, suas transações vinculadas. </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null) 
                return NotFound();

            _context.People.Remove(person);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
