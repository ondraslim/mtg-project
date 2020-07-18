using Infrastructure.Common.Entities;
using Infrastructure.Common.Query;
using Infrastructure.Common.UnitOfWork.Interfaces;
using Infrastructure.EF.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.EF
{
    public class EFQuery<TEntity, TKey> : QueryBase<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        /// <summary>
        /// Gets the <see cref="DbContext"/>.
        /// </summary>
        protected DbContext Context => ((EFUnitOfWork)Provider.GetUnitOfWorkInstance()).Context;

        /// <summary>
        ///   Initializes a new instance of the <see cref="EntityFrameworkQuery{TResult}" /> class.
        /// </summary>
        public EFQuery(IUnitOfWorkProvider provider) : base(provider)
        {
        }

        public override async Task<QueryResult<TEntity, TKey>> ExecuteAsync(IQueryable<TEntity> query)
        {
            if (OrderBy != null)
            {
                var orderByProperty = typeof(TEntity).GetProperty(OrderBy);
                query = query.OrderBy(e => orderByProperty.GetValue(e, null));
            }

            var itemsCount = query.Count();
            if (DesiredPage != null &&DesiredPage > 0)
            {
                query = query.Skip(DesiredPage.Value * PageSize).Take(PageSize);
            }

            var items = await query.ToListAsync();
            return new QueryResult<TEntity, TKey>(items, itemsCount);

        }
    }
}