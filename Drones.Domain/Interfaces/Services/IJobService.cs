using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Interfaces.Services
{
    public interface IJobService : IDisposable
    {
        public Task LogForDroneBatteries();
        public void AddJobForDroneBatteries();
    }
}
