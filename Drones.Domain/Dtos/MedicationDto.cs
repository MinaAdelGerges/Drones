using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Dtos
{
    public class MedicationDto
    {
        [Required]
        [RegularExpression(@"\b[a-zA-Z0-9-_]\b")]

        public string Name { get; set; }
        public int Weight { get; set; }
        [Required]
        [RegularExpression(@"\b[A-Z0-9-_]\b")]
        public string Code { get; set; }
        public IFormFile Image { get; set; }
    }
}
