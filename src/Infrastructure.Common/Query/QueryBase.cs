using Infrastructure.Common.Entities;
using Infrastructure.Common.UnitOfWork.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Common.Query
{
    public abstract class QueryBase<TEntity, TKey> : IQuery<TEntity, TKey> where TEntity : class, IEntity<TKey>, new()
    {
        private const int DefaultPageSize = 10;
        private string _orderBy;

        protected readonly IUnitOfWorkProvider Provider;

        /// <summary>
        /// desired page size
        /// </summary>
        public int PageSize { get; private set; } = DefaultPageSize;

        /// <summary>
        /// which page to choose, default is null
        /// </summary>
        public int? DesiredPage { get; private set; }

        /// <summary>
        /// column name we are sorting for
        /// </summary>
        public string OrderBy
        {
            get => _orderBy;
            protected set => _orderBy = GetPropertyNameIfExists(value);
        }

        /// <summary>
        /// if true, we are using ascending order, which is default
        /// </summary>
        public bool UseAscendingOrder { get; protected set; } = true;


        protected QueryBase(IUnitOfWorkProvider uowProvider)
        {
            Provider = uowProvider;
        }


        /// <summary>
        /// sets sorting for given Query
        /// </summary>
        /// <param name="orderBy"></param>
        /// <param name="ascendingOrder"></param>
        /// <returns></returns>
        public IQuery<TEntity, TKey> SortBy(string orderBy, bool ascendingOrder = true)
        {
            OrderBy = !string.IsNullOrWhiteSpace(orderBy) ? orderBy : throw new ArgumentException($"{nameof(orderBy)} must be defined!");
            UseAscendingOrder = ascendingOrder;
            return this;
        }

        /// <summary>
        /// sets paging for given Query
        /// </summary>
        /// <param name="pageToFetch"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IQuery<TEntity, TKey> Page(int pageToFetch, int pageSize = DefaultPageSize)
        {
            if (pageToFetch < 1)
            {
                throw new ArgumentException("Desired page number must be greater than zero!");
            }
            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than zero!");
            }
            DesiredPage = pageToFetch;
            PageSize = pageSize;
            return this;
        }

        /// <summary>
        /// database transaction execution
        /// </summary>
        /// <returns></returns>
        public abstract Task<QueryResult<TEntity, TKey>> ExecuteAsync(IQueryable<TEntity> queryable);



        /// <summary>
        /// returns column name if exists, otherwise empty string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string GetPropertyNameIfExists(string input)
        {
            var properties = typeof(TEntity).GetProperties().Select(prop => prop.Name);
            var matchedName = properties.FirstOrDefault(name => name.IndexOf(input, StringComparison.OrdinalIgnoreCase) >= 0);
            return matchedName ?? string.Empty;
        }
    }
}