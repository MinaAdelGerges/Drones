using Drones.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Dtos
{
    public class DroneDto
    {
        [MaxLength(100)]
        [Required(ErrorMessage = "Serial Number Required")]
        public int SerialNumber { get; set; }
        public DroneModelEnum Model { get; set; }
        [MaxLength(500)]
        [Required]
        public int Weight { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9][/\\]$/img", ErrorMessage = "End with '/' or '\\' character.")]
        //
        public float BatteryCapacity { get { return (BatteryCapacity * 100); } set { } }
        [Required]
        public DronesStateEnum State { get; set; }
    }
}
