using Infrastructure.Common.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace DAL_Common.Model.Common
{
    public class EntityBase : IEntity<Guid>
    {
        [Key]
        public virtual Guid Id { get; set; } = Guid.NewGuid(); //Ensure new Id for each entity
    }
}