using HouseholdExpenses.Domain.Entities;

namespace HouseholdExpenses.Application.Interfaces
{
    /// <summary>
    /// Define as operações para manutenção do cadastro de pessoas.
    /// </summary>
    public interface IPersonService
    {
        /// <summary> Lista todos as pessoas cadastradas. </summary>
        Task<List<Person>> GetAllAsync();

        /// <summary> Adiciona uma nova pessoa ao sistema. </summary>
        Task<Person> CreateAsync(Person person);

        /// <summary> Remove uma pessoa do sistema com base no seu ID. </summary>
        Task DeleteAsync(Guid id);
    }
}
