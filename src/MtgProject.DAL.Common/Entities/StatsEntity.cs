using DAL.Common.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Common.Entities
{
    [Table(nameof(StatsEntity))]
    public class StatsEntity : SoftDeleteEntity
    {
        public int DamageDealt { get; set; }

        public int DamageReceived { get; set; }

        public int Kills { get; set; }

        public Guid GameParticipationEntityId { get; set; }

        [ForeignKey(nameof(GameParticipationEntityId))]
        public virtual GameParticipationEntity GameParticipationEntity { get; set; }
    }
}