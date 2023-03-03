using Drones.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<IQueryable<T>> QueryBuilder(Expression<Func<T, bool>> filter = null, string include = null);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, string include = null);
        Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string include = null);
        Task<T> InsertAsync(T entity);
        Task<ICollection<T>> InsertAllAsync(ICollection<T> entities);

        Task<bool> DeleteAsync(int id);
        Task<int> UpdateAsync(T entity);
        Task<int> SaveChangesAsync();
    }
}
