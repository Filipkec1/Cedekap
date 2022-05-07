using Diplomski.Core.Repositories;
using Diplomski.Infrastructure.EfModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplomski.Infrastructure.EfRepository
{
    /// <summary>
    /// Defines repository base class.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        protected DiplomskiDbContext context { get; }

        public RepositoryBase(DiplomskiDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        protected DbSet<TEntity> GetTable()
        {
            return context.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> GetTableQueryable()
        {
            return GetTable();
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> Add(TEntity entity)
        {
            await GetTable().AddAsync(entity);

            return entity;
        }

        /// <inheritdoc />
        public virtual async Task AddRange(IEnumerable<TEntity> entities)
        {
            await GetTable().AddRangeAsync(entities);
        }

        /// <inheritdoc />
        public virtual void Delete(TEntity entity)
        {
            GetTable().Remove(entity);
        }

        /// <inheritdoc />
        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            GetTable().RemoveRange(entities);
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await GetTableQueryable()
                            .AsNoTracking()
                            .ToListAsync();
        }

        /// <inheritdoc />
        public abstract Task<TEntity> GetById(TPrimaryKey id);

        /// <inheritdoc />
        public void Update(TEntity entity)
        {
            GetTable().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            GetTable().UpdateRange(entities);
        }
    }
}
