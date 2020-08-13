using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL.Common.Model.Common;

namespace DAL.Common.Model
{
    [Table(nameof(User))]
    public class User : SoftDeleteEntity
    {
        [Required] [MaxLength(32)] public string Name { get; set; }

        /// <summary>
        /// Computed hash of user's password
        /// </summary>
        [Required] public string PasswordHash { get; set; }

        public string RolesString { get; set; } = "User";


        public virtual ICollection<GameParticipation> GameParticipations { get; set; }

        public virtual ICollection<DeckEntity> Decks { get; set; }
    }
}