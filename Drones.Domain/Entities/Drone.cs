using Drones.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Entities
{
    public class Drone
    {
        public int SerialNumber { get; set; }
        public DroneModelEnum Model { get; set; }
        public int Weight { get; set; }
        //
        public float BatteryCapacity { get { return (BatteryCapacity * 100); } set { } }
        public DronesStateEnum State { get; set; }

    }
}
