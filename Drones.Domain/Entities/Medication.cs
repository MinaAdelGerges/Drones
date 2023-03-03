using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Drones.Domain.Entities
{
    public class Medication : BaseEntity
    {

        public string Name { get; set; }
        public int Weight { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }

        //Navigation Properties
        public Nullable<int> DroneId { get; set; }
        [JsonIgnore]
        public Drone? Drone { get; set; }
    }
}
