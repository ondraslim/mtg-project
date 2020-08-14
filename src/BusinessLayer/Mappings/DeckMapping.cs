using AutoMapper;
using BusinessLayer.DTOs.Decks;
using DAL.Common.Entities;

namespace BusinessLayer.Mappings
{
    public class DeckMapping : Profile
    {
        public DeckMapping()
        {
            CreateMap<DeckCreateDto, DeckEntity>();
            CreateMap<DeckUpdateDto, DeckEntity>();
            CreateMap<DeckEntity, DeckListDto>();
            CreateMap<DeckEntity, DeckDetailDto>();
        }
    }
}