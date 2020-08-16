using DAL.Common.Entities.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Common.Entities
{
    [Table(nameof(GameParticipationEntity))]
    public class GameParticipationEntity : SoftDeleteEntity
    {
        public Guid GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual GameEntity GameEntity { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))] 
        public virtual UserEntity UserEntity { get; set; }

        public Guid DeckId { get; set; }

        [ForeignKey(nameof(DeckId))] 
        public virtual DeckEntity Deck { get; set; }


        public bool IsWinner { get; set; }


        public virtual StatsEntity StatsEntity { get; set; }
    }
}