using HouseholdExpenses.Domain.Enums;

namespace HouseholdExpenses.Domain.Entities
{
    /// <summary>
    /// Registra uma movimentação financeira individual de receita ou despesa.
    /// </summary>
    public class Transaction
    {
        /// <summary> Identificador único da transação. </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary> Detalhes do que se trata a transação. </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary> Valor monetário da operação. </summary>
        public decimal Amount { get; set; }

        /// <summary> Tipo da movimentação: Income (Receita) ou Expense (Despesa). </summary>
        public TransactionType Type { get; set; }

        /// <summary> Chave estrangeira para a categoria. </summary>
        public Guid CategoryId { get; set; }

        /// <summary> Propriedade de navegação para os dados da categoria associada. </summary>
        public Category Category { get; set; } = null!;

        /// <summary> Chave estrangeira para a pessoa que realizou a transação. </summary>
        public Guid PersonId { get; set; }

        /// <summary> Propriedade de navegação para os dados da pessoa associada. </summary>
        public Person Person { get; set; } = null!;
    }
}
