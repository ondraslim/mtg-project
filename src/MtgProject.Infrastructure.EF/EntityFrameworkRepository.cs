using System.Threading.Tasks;
using Infrastructure.Common.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF
{
    public class EntityFrameworkRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        private readonly MtgDbContext dbContext;

        public EntityFrameworkRepository()
        {
        }

        public TKey Create(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
            return entity.Id;
        }

        public void Delete(TKey id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            if (entity != null)
            {
                dbContext.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(TKey id, params string[] includes)
        {
            var ctx = dbContext.Set<TEntity>().AsQueryable();
            foreach (var include in includes)
            {
                ctx = ctx.Include(include);
            }

            return await ctx.SingleOrDefaultAsync(entity => entity.Id.Equals(id));
        }

        public void Update(TEntity entity)
        {
            var foundEntity = dbContext.Set<TEntity>().Find(entity.Id);
            dbContext.Entry(foundEntity).CurrentValues.SetValues(entity);
        }
    }
}