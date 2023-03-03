using Drones.Domain.Entities;
using Drones.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Interfaces.Services
{
    public interface IMedicationService : IRepository<Medication>
    {
        Task<ICollection<Medication>> GetLoadedModicationItems(int SerialNumber);
    }
}
