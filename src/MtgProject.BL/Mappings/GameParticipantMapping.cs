using AutoMapper;
using BusinessLayer.DTOs.GameParticipations;
using DAL.Common.Entities;

namespace BusinessLayer.Mappings
{
    public class GameParticipantMapping : Profile
    {
        public GameParticipantMapping()
        {
            CreateMap<GameParticipationEntity, GameParticipationListDto>()
                .ForMember(gp => gp.DeckName, e => e.MapFrom(g => g.Deck.Name))
                .ForMember(gp => gp.UserName, e => e.MapFrom(g => g.UserEntity.Name));
            CreateMap<GameParticipationCreateDto, GameParticipationEntity>();
        }
    }
}