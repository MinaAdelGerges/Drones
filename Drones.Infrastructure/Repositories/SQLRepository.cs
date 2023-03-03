using Drones.Domain.Interfaces.Repositories;
using Drones.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Drones.Infrastructure.Repositories
{
    public class SQLRepository<T> : IRepository<T> where T : class
    {
        protected readonly DronesDbContext _dbContext;
        protected DbSet<T> entites;
        public SQLRepository(DronesDbContext dbContext)
        {
            _dbContext = dbContext;
            entites = _dbContext.Set<T>();
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await entites.FindAsync(id);
            try
            {
                _dbContext.Remove(entity);
                await SaveChangesAsync();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }


        }

        public async Task<int> DeleteAsync(Expression<Func<T, bool>> filter)
        {

            var entity = await entites.Where(filter).FirstOrDefaultAsync();
            if (entity != null)
                _dbContext.Remove(entity);
            return await SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> filter = null, string inclue = null)
        {
            var queryResult = await QueryBuilder(filter, inclue);

            return await queryResult.FirstOrDefaultAsync();

        }

        public async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string includeMany = null)
        {
            var queryResult = await QueryBuilder(filter, includeMany);

            return await queryResult.ToListAsync();

        }

        public async Task<T> InsertAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await SaveChangesAsync();

            return (entity);
        }
        public async Task<ICollection<T>> InsertAllAsync(ICollection<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            await SaveChangesAsync();

            return (entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();

        }

        public async Task<int> UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            return await SaveChangesAsync();
        }

        public Task<IQueryable<T>> QueryBuilder(Expression<Func<T, bool>> filter = null, string includeMany = null)
        {
            var t = entites.ToList();
            IQueryable<T> query = entites.AsQueryable();
            if (filter != null)
                query = entites.Where(filter);
            if (!String.IsNullOrWhiteSpace(includeMany))
            {
                var includes = includeMany.Split(',');
                foreach (var include in includes)
                {
                    query = query.Include(include);

                }

            }

            return Task.FromResult(query);
        }
    }
}
