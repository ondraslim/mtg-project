using Infrastructure.Common.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Common.Query
{
    public interface IQuery<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
    {

        /// <summary>
        /// Adds a specified sort criteria to the query.
        /// </summary>
        IQuery<TEntity, TKey> SortBy(string sortAccordingTo, bool ascendingOrder = true);

        /// <summary>
        /// Adds a specified sort criteria to the query.
        /// </summary>
        IQuery<TEntity, TKey> Page(int pageToFetch, int pageSize = 10);

        /// <summary>
        /// Executes the query and returns the results.
        /// </summary>
        Task<QueryResult<TEntity, TKey>> ExecuteAsync(IQueryable<TEntity> query);
    }
}