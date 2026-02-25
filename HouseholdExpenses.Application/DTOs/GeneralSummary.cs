namespace HouseholdExpenses.Application.DTOs
{
    /// <summary>
    /// Objeto de transferência que consolida o balanço financeiro global de todas as pessoas.
    /// </summary>
    /// <param name="Details">Lista detalhada contendo o resumo individual de cada pessoa.</param>
    /// <param name="GrandTotalIncome">Soma total de todas as receitas de todas as pessoas.</param>
    /// <param name="GrandTotalExpense">Soma total de todas as despesas de todas as pessoas.</param>
    /// <param name="NetBalance">Saldo líquido global (Total de Receitas - Total de Despesas).</param>
    public record GeneralSummary(
    List<PersonSummary> Details,
    decimal GrandTotalIncome,
    decimal GrandTotalExpense,
    decimal NetBalance
);
}
