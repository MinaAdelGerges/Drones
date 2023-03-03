using Drones.Domain.Dtos;
using Drones.Domain.Entities;
using Drones.Domain.Enums;
using Drones.Domain.Interfaces.Repositories;
using Drones.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Services
{
    public class DronService : IDroneService
    {
        private readonly IRepository<Drone> _repository;
        public DronService(IRepository<Drone> repository)
        {
            _repository = repository;
        }

        public async Task<float> CheckDroneBatteryLevel(int SerialNumber)
        {
            var result = await _repository.GetByIdAsync(x => x.Id == SerialNumber);
            return result.BatteryCapacity;


        }

        public async Task<ICollection<Drone>> GetAllDrones()
        {

            return await _repository.GetAllAsync(null, $"{nameof(Medication)}s,{nameof(State)},{nameof(Model)}");
        }

        public async Task<ICollection<Drone>> GetAvailableDrones()
        {
            return await _repository.GetAllAsync(x => x.StateId == (int)DronesStateEnum.IDLE, $"{nameof(Medication)}s,{nameof(State)},{nameof(Model)}");
        }

        public async Task<Drone> GetDroneById(int id)
        {
            return await _repository.GetByIdAsync(x => x.Id == id, $"{nameof(Medication)}s,{nameof(State)},{nameof(Model)}");

        }

        public async Task<Drone> InsertDrone(Drone drone)
        {
            return await _repository.InsertAsync(drone);
        }
        public async Task<ResponseValidationEnum> LoadDroneWithMedicationItems(int serialNumber, string medicationCode)
        {
            var drone = await GetDroneById(serialNumber);
            if (drone.StateId == (int)DronesStateEnum.IDLE)
                return ResponseValidationEnum.NotAvailable;

            if (drone.BatteryCapacity < 25.0)
                return ResponseValidationEnum.BatteryCapacity;
            if (drone.Weight < drone.Medications.Sum(x => x.Weight))
                return ResponseValidationEnum.Weight;

            drone.StateId = (int)DronesStateEnum.LOADING;
            drone.Medications.Add(new Medication() { Code = medicationCode });
            await _repository.UpdateAsync(drone);
            return ResponseValidationEnum.Done;
        }
        public async Task<ICollection<Drone>> InsertDrones(ICollection<Drone> drones)
        {
            return await _repository.InsertAllAsync(drones);
        }

    }
}
