using Drones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {

        Task<List<Drone>> GetDrones();
        Task<bool> AddDrone(Drone drone);

        Task<Drone> GetDroneById(int id);



    }
}
