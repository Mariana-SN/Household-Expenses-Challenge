using HouseholdExpenses.Application.DTOs;
using HouseholdExpenses.Application.Interfaces;
using HouseholdExpenses.Domain.Entities;
using HouseholdExpenses.Domain.Enums;
using HouseholdExpenses.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseholdExpenses.Application.Services
{
    /// <summary>
    /// Serviço central que processa transações financeiras e gera relatórios consolidados.
    /// </summary>
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context; 

        public TransactionService(AppDbContext context) => _context = context;

        /// <summary>
        /// Cria uma transação validando regras de negócio específicas: idade e tipo de categoria.
        /// </summary>
        public async Task<Transaction> CreateTransactionAsync(TransactionRequest request)
        {
            var person = await _context.People.FindAsync(request.PersonId)
                ?? throw new Exception("Pessoa não encontrada.");

            var category = await _context.Categories.FindAsync(request.CategoryId)
                ?? throw new Exception("Categoria não encontrada.");

            if (person.Age < 18 && request.Type == TransactionType.Income)
            {
                throw new InvalidOperationException("Menores de 18 anos podem registrar apenas despesas.");
            }

            ValidateCategoryPurpose(request.Type, category.Purpose);

            var transaction = new Transaction
            {
                Description = request.Description,
                Amount = Math.Abs(request.Amount),
                Type = request.Type,
                CategoryId = request.CategoryId,
                PersonId = request.PersonId
            };

            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        /// <summary>
        /// Valida se uma transação (Receita/Despesa) pode ser atribuída a uma categoria específica.
        /// </summary>
        private void ValidateCategoryPurpose(TransactionType transType, CategoryPurpose catPurpose)
        {
            if (catPurpose == CategoryPurpose.Both) return;

            if (transType == TransactionType.Income && catPurpose == CategoryPurpose.Expense)
                throw new InvalidOperationException("Essa categoria é restringida apenas para Despesa.");

            if (transType == TransactionType.Expense && catPurpose == CategoryPurpose.Income)
                throw new InvalidOperationException("Essa categoria é restringida apenas para Receita.");
        }

        /// <summary>
        /// Gera um resumo financeiro geral, calculando totais por pessoa e o saldo líquido global.
        /// </summary>
        public async Task<GeneralSummary> GetFinancialSummaryAsync()
        {
            var people = await _context.People.Include(p => p.Transactions).ToListAsync();

            var personSummaries = people.Select(p => new PersonSummary(
                p.Id,
                p.Name,
                TotalIncome: p.Transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount),
                TotalExpense: p.Transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount),
                Balance: p.Transactions.Where(t => t.Type == TransactionType.Income).Sum(t => t.Amount) -
                         p.Transactions.Where(t => t.Type == TransactionType.Expense).Sum(t => t.Amount)
            )).ToList();

            return new GeneralSummary(
                Details: personSummaries,
                GrandTotalIncome: personSummaries.Sum(s => s.TotalIncome),
                GrandTotalExpense: personSummaries.Sum(s => s.TotalExpense),
                NetBalance: personSummaries.Sum(s => s.Balance)
            );
        }

        public async Task<List<Transaction>> GetAllTransactionsAsync() =>
            await _context.Transactions.Include(t => t.Category).Include(t => t.Person).ToListAsync();
    }
}
