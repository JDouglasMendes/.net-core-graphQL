using GraphQL.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.API.Context
{
    public class GraphQLContext : DbContext
    {
  
        public GraphQLContext(DbContextOptions<GraphQLContext> options)
        : base(options)
        { }

        public DbSet<Role> Cargos { get; set; }
        public DbSet<Employee> Funcionario { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<Contracts> Contratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(x => x.Funcionarios)
                .WithOne(x => x.Role);

            modelBuilder.Entity<Employee>()
                .HasMany(x => x.Dependentes)
                .WithOne(x => x.Funcionario);

            modelBuilder.Entity<Employee>()
                .HasMany(x => x.Contracts)
                .WithOne(x => x.Employee);

            base.OnModelCreating(modelBuilder);
        }               
    }
}