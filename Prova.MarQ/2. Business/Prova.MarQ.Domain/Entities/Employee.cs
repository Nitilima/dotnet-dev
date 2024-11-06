using System;
using System.ComponentModel.DataAnnotations;

namespace Prova.MarQ.Domain.Entities
{
    public class Employee : Base
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Document { get; set; }

        [Required]
        public string PIN { get; set; }

        [Required]
        public Guid CompanyId { get; set; }

        public Company Company { get; set; }

        public int EmployeeId { get; set; }

        public bool IsDeleted { get; set; }
    }
}