using AutoMapper;
using BusinessLayer.DTOs.GameParticipations;
using DAL.Common.Model;

namespace BusinessLayer.Mappings
{
    public class GameParticipantMapping : Profile
    {
        public GameParticipantMapping()
        {
            CreateMap<GameParticipation, GameParticipationListDto>()
                .ForMember(gp => gp.DeckName, e => e.MapFrom(g => g.Deck.Name))
                .ForMember(gp => gp.UserName, e => e.MapFrom(g => g.User.Name));
            CreateMap<GameParticipationCreateDto, GameParticipation>();
        }
    }
}