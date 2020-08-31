using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.API.Models
{
    public class Funcionario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public List<Contrato> Contratos { get; set; }
        public List<Dependente> Dependentes { get; set; }

        [ForeignKey(nameof(CargoId))]
        public virtual Cargo Cargo { get; set; }
        public Guid CargoId { get; set; }
    }
}