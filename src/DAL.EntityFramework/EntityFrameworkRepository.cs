using DAL.EntityFramework.Data;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace DAL.EntityFramework
{
    public class EntityFrameworkRepository<TEntity, TKey> : EntityFrameworkRepository<TEntity, TKey, MtgDbContext>
        where TEntity : class, IEntity<TKey>, new()
    {

        public EntityFrameworkRepository(EntityFrameworkUnitOfWorkProvider entityFrameworkUnitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(entityFrameworkUnitOfWorkProvider, dateTimeProvider)
        {
        }
    }
}