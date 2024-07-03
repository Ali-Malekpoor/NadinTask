using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin.Domain.DTOs
{
    public class CreateProductDTO
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ProductDate { get; set; }
        [Required]
        [EmailAddress]
        public string ManufactureEmail { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ManufacturePhone { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
    }
}
