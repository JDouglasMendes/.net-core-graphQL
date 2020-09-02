using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.API.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }

        public List<Contracts> Contracts { get; set; }
        public List<Dependente> Dependentes { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}