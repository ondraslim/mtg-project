using AutoMapper;
using BusinessLayer.DTOs.Decks;
using BusinessLayer.Facades.Common;
using BusinessLayer.Queries;
using BusinessLayer.Services;
using DAL.EntityFramework.Data;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Facades
{
    public class DeckFacade : FacadeBase
    {
        private readonly DeckService deckService;
        private readonly Func<DeckGetByUserQuery> deckGetByUserQueryFactory;

        public DeckFacade(
            EntityFrameworkUnitOfWorkProvider<MtgDbContext> unitOfWorkProvider,
            DeckService deckService,
            Func<DeckGetByUserQuery> deckGetByUserQueryFactory,
            IMapper mapper)
            : base(unitOfWorkProvider, mapper)
        {
            this.deckService = deckService;
            this.deckGetByUserQueryFactory = deckGetByUserQueryFactory;
        }

        public async Task<List<DeckListDto>> GetAllAsync()
        {
            using var unitOfWork = UnitOfWorkProvider.Create();
            return Mapper.Map<List<DeckListDto>>(await deckService.GetAllAsync());
        }

        public async Task<IList<DeckListDto>> GetByUserAsync(Guid userId)
        {
            using var unitOfWork = UnitOfWorkProvider.Create();
            var deckGetByUserQuery = deckGetByUserQueryFactory();
            deckGetByUserQuery.UserId = userId;

            return await deckGetByUserQuery.ExecuteAsync();
        }
    }
}