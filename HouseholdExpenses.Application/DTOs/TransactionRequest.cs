using HouseholdExpenses.Domain.Enums;

namespace HouseholdExpenses.Application.DTOs
{
    /// <summary>
    /// Modelo de entrada para a criação de uma nova transação financeira.
    /// </summary>
    /// <param name="Description">Breve descrição ou título da transação (ex: "Salário" ou "Supermercado").</param>
    /// <param name="Amount">Valor monetário da transação.</param>
    /// <param name="Type">Define se é uma Receita (Income) ou Despesa (Expense).</param>
    /// <param name="CategoryId">ID da categoria à qual esta transação pertence.</param>
    /// <param name="PersonId">ID da pessoa responsável pela transação.</param>
    public record TransactionRequest(
    string Description,
    decimal Amount,
    TransactionType Type,
    Guid CategoryId,
    Guid PersonId
);
}
