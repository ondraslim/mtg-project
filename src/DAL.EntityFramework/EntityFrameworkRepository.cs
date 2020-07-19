using DAL.EntityFramework.Data;
using Infrastructure.Common;
using Infrastructure.Common.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DAL.EntityFramework
{
    public class EntityFrameworkRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        protected readonly MtgDbContext DbContext;

        public EntityFrameworkRepository(MtgDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public TKey Create(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            return entity.Id;
        }

        public void Delete(TKey id)
        {
            var entity = DbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                DbContext.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(TKey id, params string[] includes)
        {
            var ctx = DbContext.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                ctx = ctx.Include(include);
            }

            return await ctx.SingleOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public void Update(TEntity entity)
        {
            var foundEntity = DbContext.Set<TEntity>().Find(entity.Id);
            DbContext.Entry(foundEntity).CurrentValues.SetValues(entity);
        }
    }
}