using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Entities
{
    public class Medication
    {

        public string Name { get; set; }
        public int Weight { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }

        public int DroneId { get; set; }
        public Drone Drone { get; set; }
    }
}
