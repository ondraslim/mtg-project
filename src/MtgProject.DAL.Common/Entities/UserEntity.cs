using DAL.Common.Entities.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Common.Entities
{
    [Table(nameof(UserEntity))]
    public class UserEntity : SoftDeleteEntity
    {
        [Required] [MaxLength(32)] public string Name { get; set; }

        /// <summary>
        /// Computed hash of user's password
        /// </summary>
        [Required] public string PasswordHash { get; set; }

        public string RolesString { get; set; } = "User";


        public virtual ICollection<GameParticipationEntity> GameParticipations { get; set; } = new List<GameParticipationEntity>();

        public virtual ICollection<DeckEntity> Decks { get; set; } = new List<DeckEntity>();
    }
}