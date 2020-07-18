using Infrastructure.Common.Entities;
using System;

namespace DAL_Common.Model.Common
{
    public class EntityChangeTracker : EntityBase, IEntityChangeTracker<Guid>
    {

        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}