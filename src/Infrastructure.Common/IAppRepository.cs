using Riganti.Utils.Infrastructure.Core;

namespace Infrastructure.Common
{
    public interface IAppRepository<TEntity, in TKey> : IRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
    }
}