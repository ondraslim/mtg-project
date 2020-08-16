using Riganti.Utils.Infrastructure.Core;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Common
{
    public class RepositoryService<TRepository, TEntity, TKey> : ServiceBase
    where TEntity : class, IEntity<TKey>, new()
    where TRepository : class, IRepository<TEntity, TKey>
    {
        protected readonly TRepository Repository;

        public RepositoryService(TRepository repository)
        {
            Repository = repository;
        }


        public TKey Insert(TEntity entity)
        {
            Repository.Insert(entity);
            return entity.Id;
        }

        public void Insert(IEnumerable<TEntity> entities)
        {
            Repository.Insert(entities);
        }

        public void Delete(TKey id)
        {
            Repository.Delete(id);
        }

        public void Delete(TEntity entity)
        {
            Repository.Delete(entity);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            Repository.Delete(entities);
        }
        
        public void Delete(IEnumerable<TKey> ids)
        {
            Repository.Delete(ids);
        }        

        public TEntity GetById(TKey id, IIncludeDefinition<TEntity>[] includes)
        {
            return Repository.GetById(id, includes);
        }

        public Task<TEntity> GetByIdAsync(TKey id, IIncludeDefinition<TEntity>[] includes)
        {
            return Repository.GetByIdAsync(id, includes);
        }

        public Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, TKey id, IIncludeDefinition<TEntity>[] includes)
        {
            return Repository.GetByIdAsync(cancellationToken, id, includes);
        }

        public void Update(TEntity entity)
        {
            Repository.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            Repository.Update(entities);
        }
    }
}