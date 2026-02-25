using HouseholdExpenses.Application.DTOs;
using HouseholdExpenses.Domain.Entities;

namespace HouseholdExpenses.Application.Interfaces
{
    /// <summary>
    /// Interface principal para processamento de movimentações financeiras e balanços.
    /// </summary>
    public interface ITransactionService
    {
        /// <summary>
        /// Processa e valida uma nova transação (receita ou despesa).
        /// </summary>
        /// <param name="request">Dados da transação vindos da camada de apresentação.</param>
        Task<Transaction> CreateTransactionAsync(TransactionRequest request);

        /// <summary> Recupera o histórico completo de transações registradas. </summary>
        Task<List<Transaction>> GetAllTransactionsAsync();

        /// <summary>
        /// Gera o relatório consolidado de receitas, despesas e saldos individuais/globais.
        /// </summary>
        Task<GeneralSummary> GetFinancialSummaryAsync();
    }
}
