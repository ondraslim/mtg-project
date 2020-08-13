using System.ComponentModel.DataAnnotations.Schema;
using DAL.Common.Model.Common;

namespace DAL.Common.Model
{
    [Table(nameof(Stats))]
    public class Stats : SoftDeleteEntity
    {
        public virtual GameParticipation GameParticipation { get; set; }

        public int DamageDealt { get; set; }

        public int DamageReceived { get; set; }

        public int Kills { get; set; }
    }
}