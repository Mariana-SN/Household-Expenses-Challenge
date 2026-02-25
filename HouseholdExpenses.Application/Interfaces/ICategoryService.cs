using HouseholdExpenses.Domain.Entities;

namespace HouseholdExpenses.Application.Interfaces
{
    /// <summary>
    /// Define as operações permitidas para o gerenciamento de categorias.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary> Obtém a lista completa de categorias disponíveis. </summary>
        Task<List<Category>> GetAllAsync();

        /// <summary> Cria uma nova categoria com base nos dados fornecidos. </summary>
        Task<Category> CreateAsync(Category category);
    }
}
