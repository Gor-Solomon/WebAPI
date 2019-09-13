using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCL.DAL.Repository.Base
{
    public interface IBaseRepository<TEntity, TDBContext> where TEntity : class where TDBContext : DbContext
    {
        Task<TEntity> GetById(int Id);
        Task<TEntity> Add(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Edit(TEntity entity);
        void RemoveById(int Id);
    }
}
