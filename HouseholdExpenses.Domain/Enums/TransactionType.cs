namespace HouseholdExpenses.Domain.Enums
{
    /// <summary>
    /// Especifica o tipo de movimentação financeira que está sendo realizada.
    /// </summary>
    public enum TransactionType 
    {
        /// <summary> Indica uma entrada de recurso financeiro (Receita). </summary>
        Income = 1,
        /// <summary> Indica uma saída de recurso financeiro (Despesa). </summary>
        Expense = 2
    }
}
