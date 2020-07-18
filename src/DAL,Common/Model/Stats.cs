using DAL_Common.Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_Common.Model
{
    [Table(nameof(Stats))]
    public class Stats : EntityChangeTracker
    {
        public virtual GameParticipation GameParticipation { get; set; }

        public int DamageDealt { get; set; }

        public int DamageReceived { get; set; }

        public int Kills { get; set; }
    }
}