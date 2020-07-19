using AutoMapper;
using BusinessLayer.DTOs.Decks;
using DAL.Common.Model;

namespace BusinessLayer.Mappings
{
    public class DeckMapping : Profile
    {
        public DeckMapping()
        {
            CreateMap<DeckCreateDto, Deck>();
            CreateMap<DeckUpdateDto, Deck>();
            CreateMap<Deck, DeckListDto>();
            CreateMap<Deck, DeckDetailDto>();
        }
    }
}