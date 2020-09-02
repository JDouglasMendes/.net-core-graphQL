using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.API.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Descricao { get; set; }

        public List<Employee> Funcionarios {get;set;}
    }
}