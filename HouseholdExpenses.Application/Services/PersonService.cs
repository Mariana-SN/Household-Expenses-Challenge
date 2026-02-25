using HouseholdExpenses.Application.Interfaces;
using HouseholdExpenses.Domain.Entities;
using HouseholdExpenses.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseholdExpenses.Application.Services
{
    /// <summary>
    /// Serviço responsável pela gestão de pessoas do sistema.
    /// </summary>
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;

        public PersonService(AppDbContext context) => _context = context;

        /// <summary>
        /// Lista todos as pessoas cadastradas.
        /// </summary>
        public async Task<List<Person>> GetAllAsync() => await _context.People.ToListAsync();

        /// <summary>
        /// Adiciona uma nova pessoa ao sistema.
        /// </summary>
        public async Task<Person> CreateAsync(Person person)
        {
            _context.People.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        /// <summary>
        /// Remove uma pessoa com base no seu identificador único.
        /// </summary>
        /// <param name="id">Guid da pessoa a ser removida.</param>
        public async Task DeleteAsync(Guid id)
        {
            var person = await _context.People.FindAsync(id);
            if (person != null)
            {
                _context.People.Remove(person);
                await _context.SaveChangesAsync();
            }
        }
    }
}
