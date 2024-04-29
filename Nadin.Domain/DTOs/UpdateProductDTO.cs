using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin.Domain.DTOs
{
    public class UpdateProductDTO
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
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
