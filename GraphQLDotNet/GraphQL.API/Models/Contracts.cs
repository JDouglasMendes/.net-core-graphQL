using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL.API.Models
{
    public class Contracts
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime InitData { get; set; }
        public DateTime? FinishDate { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }
        public Guid EmployeeId { get; set; }
    }
}