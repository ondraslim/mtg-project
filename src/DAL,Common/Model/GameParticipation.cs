using DAL_Common.Model.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_Common.Model
{
    [Table(nameof(GameParticipation))]
    public class GameParticipation : EntityChangeTracker
    {
        public Guid GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))] 
        public virtual User User { get; set; }

        public Guid DeckId { get; set; }

        [ForeignKey(nameof(DeckId))] 
        public virtual Deck Deck { get; set; }

        public Guid StatsId { get; set; }

        [ForeignKey(nameof(StatsId))] 
        public virtual Stats Stats { get; set; }

        public bool IsWinner { get; set; }
    }
}