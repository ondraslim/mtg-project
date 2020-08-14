using DAL.Common.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Common.Entities
{
    [Table(nameof(DeckEntity))]
    public class DeckEntity : SoftDeleteEntity
    {
        [Required, MaxLength(32)]
        public string Name { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserEntity UserEntity { get; set; }

        public virtual ICollection<GameParticipationEntity> GameParticipations { get; set; }

    }
}