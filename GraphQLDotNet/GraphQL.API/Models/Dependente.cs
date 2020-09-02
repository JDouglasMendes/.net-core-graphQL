using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.API.Models
{
    public class Dependente
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        public Employee Funcionario { get; set; }
        public Guid FuncionarioId { get; set; }
    }
}