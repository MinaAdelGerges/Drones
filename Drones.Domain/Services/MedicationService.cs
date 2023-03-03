using Drones.Domain.Entities;
using Drones.Domain.Enums;
using Drones.Domain.Interfaces.Repositories;
using Drones.Domain.Interfaces.Services;
using System.Linq.Expressions;


namespace Drones.Domain.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IRepository<Medication> _repository;
        public MedicationService(IRepository<Medication> repository)
        {
            _repository = repository;
        }
        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Medication>> GetAllAsync(Expression<Func<Medication, bool>> filter = null, string include = null)
        {
            return await _repository.GetAllAsync(null, "Drone");
        }

        public Task<Medication> GetByIdAsync(Expression<Func<Medication, bool>> filter = null, string include = null)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Medication>> GetLoadedModicationItems(int SerialNumber)
        {

            return await _repository.GetAllAsync(x => x.Drone.StateId == (int)DronesStateEnum.LOADED && x.DroneId == SerialNumber);
        }

        public Task<ICollection<Medication>> InsertAllAsync(ICollection<Medication> entities)
        {
            throw new NotImplementedException();
        }

        public Task<Medication> InsertAsync(Medication entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Medication>> QueryBuilder(Expression<Func<Medication, bool>> filter = null, string include = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Medication entity)
        {
            throw new NotImplementedException();
        }
    }
}
