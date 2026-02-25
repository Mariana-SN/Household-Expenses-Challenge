namespace HouseholdExpenses.Domain.Entities
{
    /// <summary>
    /// Representa uma pessoa do sistema que pode realizar transações financeiras.
    /// </summary>
    public class Person
    {
        /// <summary> Identificador único da pessoa. </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary> Nome completo da pessoa. </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary> 
        /// Idade da pessoa. 
        /// Utilizada no serviço para validar se a pessoa pode ou não registrar receitas.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Coleção de transações vinculadas a esta pessoa.
        /// O atributo JsonIgnore evita ciclos de referência infinitos durante a serialização da API.
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
