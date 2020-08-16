using DAL.EntityFramework.Data;
using Infrastructure.Common;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace DAL.EntityFramework.Repository
{
    public class AppEntityFrameworkRepository<TEntity, TKey> : EntityFrameworkRepository<TEntity, TKey, MtgDbContext>, IAppRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {

        public AppEntityFrameworkRepository(EntityFrameworkUnitOfWorkProvider entityFrameworkUnitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(entityFrameworkUnitOfWorkProvider, dateTimeProvider)
        {
        }
    }
}