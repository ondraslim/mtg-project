using DAL_Common.Model.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_Common.Model
{
    [Table(nameof(User))]
    public class User : EntityChangeTracker
    {
        [Required] [MaxLength(32)] public string Name { get; set; }

        /// <summary>
        /// Computed hash of user's password
        /// </summary>
        [Required] public string PasswordHash { get; set; }

        public string RolesString { get; set; } = "User";


        public override string ToString()
        {
            return Name;
        }

        public virtual ICollection<GameParticipation> GameParticipations { get; set; }

        public virtual ICollection<Deck> Decks { get; set; }
    }
}