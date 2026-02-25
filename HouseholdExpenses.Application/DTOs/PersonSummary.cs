namespace HouseholdExpenses.Application.DTOs
{
    /// <summary>
    /// Objeto que representa o resumo financeiro individual de uma pessoa.
    /// </summary>
    /// <param name="PersonId">Identificador único da pessoa no banco de dados.</param>
    /// <param name="Name">Nome completo do membro da família.</param>
    /// <param name="TotalIncome">Soma de todas as entradas financeiras desta pessoa.</param>
    /// <param name="TotalExpense">Soma de todas as saídas financeiras desta pessoa.</param>
    /// <param name="Balance">Saldo individual (Receitas - Despesas).</param>
    public record PersonSummary(
    Guid PersonId,
    string Name,
    decimal TotalIncome,
    decimal TotalExpense,
    decimal Balance
);
}
