using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCL.DAL.Repository.Base
{
    public abstract class BaseRepository<TEntity, TDBContext> : IBaseRepository<TEntity, TDBContext>
        where TEntity : class
        where TDBContext : DbContext 
    {
        readonly DbContext _dbContext;
        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<TEntity> Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException(nameof(entity));

            var result = await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }

        public virtual async Task<TEntity> Edit(TEntity entity)
        {
            var employee = _dbContext.Set<TEntity>().Attach(entity);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int Id)
        {
            if (Id == 0)
                throw new ArgumentException(nameof(Id));

            var result = await _dbContext.Set<TEntity>().FindAsync(Id);

            return result;
        }

        public virtual async void RemoveById(int Id)
        {
            if (Id == 0)
                throw new ArgumentException(nameof(Id));

            var result = await _dbContext.Set<TEntity>().FindAsync(Id);

            if (result != null)
            {
                _dbContext.Set<TEntity>().Remove(result);
            }
        }
    }
}
