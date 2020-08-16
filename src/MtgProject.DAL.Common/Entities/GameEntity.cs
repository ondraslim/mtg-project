using DAL.Common.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Common.Entities
{
    [Table(nameof(GameEntity))]
    public class GameEntity : SoftDeleteEntity
    {
        public int TurnCount { get; set; }

        public int StartingHp { get; set; }

        public virtual ICollection<GameParticipationEntity> GameParticipations { get; set; } = new List<GameParticipationEntity>();
    }
}