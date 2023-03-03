using Drones.Domain.Dtos;
using Drones.Domain.Entities;
using Drones.Domain.Enums;
using Drones.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Interfaces.Services
{
    public interface IDroneService
    {
        public Task<ICollection<Drone>> GetAllDrones();
        public Task<Drone> GetDroneById(int id);
        public Task<Drone> InsertDrone(Drone drone);
        public Task<ICollection<Drone>> InsertDrones(ICollection<Drone> drones);
        public Task<ICollection<Drone>> GetAvailableDrones();
        public Task<float> CheckDroneBatteryLevel(int SerialNumber);
        public Task<ResponseValidationEnum> LoadDroneWithMedicationItems(int SerialNumber, string medicationCode);

    }
}
