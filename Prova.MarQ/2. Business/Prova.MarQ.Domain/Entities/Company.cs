using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prova.MarQ.Domain.Entities
{
    public class Company : Base
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Document { get; set; }

        public List<Employee> Employees { get; set; }

        public new Guid Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}