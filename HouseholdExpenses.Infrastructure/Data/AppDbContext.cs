using HouseholdExpenses.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseholdExpenses.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using HouseholdExpenses.Domain.Entities;

    /// <summary>
    /// Contexto de dados da aplicação. 
    /// Responsável por traduzir as entidades do domínio em tabelas do banco de dados.
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        /// <summary>
        /// Configuração refinada do modelo de dados através da Fluent API.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Transactions)
                .WithOne(t => t.Person)
                .HasForeignKey(t => t.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
            });

            modelBuilder.Entity<Category>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).HasMaxLength(400).IsRequired();
            });

            modelBuilder.Entity<Transaction>(entity => {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Description).HasMaxLength(400).IsRequired();

                entity.Property(e => e.Amount).HasColumnType("decimal(18,2)");
            });
        }
    }
}
