using System;
using System.Linq;
using AutoMapper;
using BusinessLayer.DTOs.Decks;
using DAL.Common.Model;
using DAL.EntityFramework;
using Riganti.Utils.Infrastructure.Core;

namespace BusinessLayer.Queries
{
    public class DeckGetByUserQuery : AppEntityFrameworkQueryBase<DeckListDto, DeckEntity, Guid>
    {
        public Guid UserId { get; set; }

        public DeckGetByUserQuery(IUnitOfWorkProvider unitOfWorkProvider, IMapper mapper)
            : base(unitOfWorkProvider, mapper)
        {
        }

        protected override IQueryable<DeckEntity> FilterQuery(IQueryable<DeckEntity> query)
        {
            return query.Where(deck => deck.UserId == UserId);
        }
    }
}