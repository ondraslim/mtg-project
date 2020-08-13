using Infrastructure.Common.Entity;
using System;
using System.ComponentModel.DataAnnotations;
using Riganti.Utils.Infrastructure.Core;

namespace DAL.Common.Model.Common
{
    public class EntityBase : IEntity<Guid>
    {
        [Key]
        public virtual Guid Id { get; set; } = Guid.NewGuid(); //Ensure new Id for each entity
    }
}