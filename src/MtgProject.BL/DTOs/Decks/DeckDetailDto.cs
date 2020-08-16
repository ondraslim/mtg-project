using BusinessLayer.DTOs.Common;
using BusinessLayer.DTOs.Users;
using System;

namespace BusinessLayer.DTOs.Decks
{
    public class DeckDetailDto : BaseDto
    {
        public string Name { get; set; }

        public Guid UserId { get; set; }

        public virtual UserDetailDto User { get; set; }
    }
}