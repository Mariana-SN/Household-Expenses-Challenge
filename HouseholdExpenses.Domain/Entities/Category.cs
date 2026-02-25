using HouseholdExpenses.Domain.Enums;

namespace HouseholdExpenses.Domain.Entities
{
    /// <summary>
    /// Representa a classificação de uma transação financeira (ex: Alimentação, Salário, Lazer).
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Identificador único da categoria. 
        /// Inicializado automaticamente com um novo Guid para facilitar a criação.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Nome ou descrição da categoria (ex: "Aluguel", "Freelance").
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Define a finalidade da categoria através do Enum CategoryPurpose.
        /// Determina se a categoria aceita Receitas, Despesas ou ambos.
        /// </summary>
        public CategoryPurpose Purpose { get; set; }
    }
}
