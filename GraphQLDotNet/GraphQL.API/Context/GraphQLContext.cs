using GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Context
{
    public class GraphQLContext : DbContext
    {
  
        public GraphQLContext(DbContextOptions<GraphQLContext> options)
        : base(options)
        { }

        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>()
                .HasMany(x => x.Funcionarios)
                .WithOne(x => x.Cargo);

            modelBuilder.Entity<Funcionario>()
                .HasMany(x => x.Dependentes)
                .WithOne(x => x.Funcionario);

            modelBuilder.Entity<Funcionario>()
                .HasMany(x => x.Contratos)
                .WithOne(x => x.Funcionario);

            base.OnModelCreating(modelBuilder);
        }               
    }
}