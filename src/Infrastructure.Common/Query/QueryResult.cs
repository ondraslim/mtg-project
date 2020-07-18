using Infrastructure.Common.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Common.Query
{
    public class QueryResult<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// Total number of items for the query
        /// </summary>
        public long TotalItemsCount { get; }

        /// <summary>
        /// Number of page (indexed from 1) which was requested
        /// </summary>
        public int? RequestedPageNumber { get; }

        /// <summary>
        /// Size of the page
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// The query results page
        /// </summary>
        public IEnumerable<TEntity> Items { get; }

        /// <summary>
        /// determine if we are to use paging
        /// </summary>
        public bool PagingEnabled => RequestedPageNumber != null;

        public QueryResult(IEnumerable<TEntity> items, long totalItemsCount, int pageSize = 10,
            int? requestedPageNumber = null)
        {
            TotalItemsCount = totalItemsCount;
            RequestedPageNumber = requestedPageNumber;
            PageSize = pageSize;
            Items = items;
        }

        #region equality override

        protected bool Equals(QueryResult<TEntity, TKey> other)
        {
            return TotalItemsCount == other.TotalItemsCount &&
                   RequestedPageNumber == other.RequestedPageNumber &&
                   PageSize == other.PageSize &&
                   Items.All(entity => other.Items.Select(item => item.Id).Contains(entity.Id));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() &&
                   Equals((QueryResult<TEntity, TKey>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = TotalItemsCount.GetHashCode();
                hashCode = (hashCode * 397) ^ RequestedPageNumber.GetHashCode();
                hashCode = (hashCode * 397) ^ PageSize;
                hashCode = (hashCode * 397) ^ (Items != null ? Items.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
    }
}