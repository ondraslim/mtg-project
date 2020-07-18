using DAL_Common.Model.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_Common.Model
{
    [Table(nameof(Game))]
    public class Game : EntityChangeTracker
    {
        public int TurnCount { get; set; }

        public int StartingHp { get; set; }

        public virtual ICollection<GameParticipation> GameParticipations { get; set; }
    }
}