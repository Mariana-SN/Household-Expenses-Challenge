namespace HouseholdExpenses.Domain.Enums
{
    /// <summary>
    /// Define a finalidade permitida para uma categoria.
    /// Utilizado para validar se uma transação é compatível com a classificação escolhida.
    /// </summary>
    public enum CategoryPurpose 
    {
        /// <summary> A categoria só aceita registros de entrada (Receitas). </summary>
        Income = 1,
        /// <summary> A categoria só aceita registros de saída (Despesas). </summary>
        Expense = 2,
        /// <summary> A categoria é flexível e aceita tanto entradas quanto saídas. </summary>
        Both = 3
    }
}
