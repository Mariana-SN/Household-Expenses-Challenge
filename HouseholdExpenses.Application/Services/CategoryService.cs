using HouseholdExpenses.Application.Interfaces;
using HouseholdExpenses.Domain.Entities;
using HouseholdExpenses.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseholdExpenses.Application.Services
{
    /// <summary>
    /// Serviço responsável pelo gerenciamento de categorias de transações.
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context) => _context = context;

        /// <summary>
        /// Recupera todas as categorias cadastradas no banco de dados.
        /// </summary>
        public async Task<List<Category>> GetAllAsync() => await _context.Categories.ToListAsync();

        /// <summary>
        /// Realiza a persistência de uma nova categoria.
        /// </summary>
        /// <param name="category">Objeto contendo os dados da categoria (Nome e Propósito).</param>
        public async Task<Category> CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}
