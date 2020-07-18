using System;

namespace Infrastructure.Common.Entities
{
    public interface IEntityChangeTracker<TKey> : IEntity<TKey>
    {
        /// <summary>
        /// Date of entity creation
        /// </summary>
        DateTime? Created { get; set; }

        /// <summary>
        /// Date of entity modification
        /// </summary>
        DateTime? Modified { get; set; }

        /// <summary>
        /// Date of entity deletion
        /// </summary>
        DateTime? Deleted { get; set; }
    }
}