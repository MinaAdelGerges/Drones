using Drones.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Entities
{
    public class Drone : BaseEntity
    {
        public Drone()
        {
            SerialNumber = Id;
        }
        [NotMapped]
        public int SerialNumber { get; set; }

        public int Weight { get; set; }

        public float BatteryCapacity { get; set; }

        //Navigation properties
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public ICollection<Medication> Medications { get; set; }

    }
}
