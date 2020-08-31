using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.API.Models
{
    public class Contrato
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        public virtual Funcionario Funcionario { get; set; }
        public Guid FuncionarioId { get; set; }
    }
}