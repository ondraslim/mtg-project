using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Common.Model.Common;

namespace DAL.Common.Model
{
    [Table(nameof(Game))]
    public class Game : SoftDeleteEntity
    {
        public int TurnCount { get; set; }

        public int StartingHp { get; set; }

        public virtual ICollection<GameParticipation> GameParticipations { get; set; }
    }
}