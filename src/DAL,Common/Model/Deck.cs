using DAL_Common.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL_Common.Model
{
    [Table(nameof(Deck))]
    public class Deck : EntityChangeTracker
    {
        [Required, MaxLength(32)] 
        public string Name { get; set; }

        [MaxLength(1000)] 
        public string Description { get; set; }

        public bool IsVisible { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public virtual ICollection<GameParticipation> GameParticipations { get; set; }

    }
}