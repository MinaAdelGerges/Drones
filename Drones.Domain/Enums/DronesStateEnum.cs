using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Enums
{
    public enum DronesStateEnum
    {
        IDLE = 1,
        LOADING = 2,
        LOADED = 3,
        DELIVERING = 4,
        DELIVERED = 5,
        RETURNING = 6
    }
}
