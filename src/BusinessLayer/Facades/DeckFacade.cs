using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.DTOs.Decks;
using BusinessLayer.Queries;
using BusinessLayer.Repositories;
using DAL.EntityFramework.Data;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace BusinessLayer.Facades
{
    public class FacadeBase
    {
        protected readonly EntityFrameworkUnitOfWorkProvider<MtgDbContext> unitOfWorkProvider;

        public FacadeBase(EntityFrameworkUnitOfWorkProvider<MtgDbContext> unitOfWorkProvider)
        {
            this.unitOfWorkProvider = unitOfWorkProvider;
        }
    }

    public class DeckFacade : FacadeBase
    {
        private readonly DeckRepository deckRepository;
        private readonly Func<DeckGetByUserQuery> deckGetByUserQueryFactory;
        private readonly IMapper mapper;

        public DeckFacade(
            EntityFrameworkUnitOfWorkProvider<MtgDbContext> unitOfWorkProvider,
            DeckRepository deckRepository,
            Func<DeckGetByUserQuery> deckGetByUserQueryFactory,
            IMapper mapper)
            : base(unitOfWorkProvider)
        {
            this.deckRepository = deckRepository;
            this.deckGetByUserQueryFactory = deckGetByUserQueryFactory;
            this.mapper = mapper;
        }

        public async Task<List<DeckListDto>> GetAllAsync()
        {
            using var unitOfWork = unitOfWorkProvider.Create();
            return mapper.Map<List<DeckListDto>>(await deckRepository.GetAllAsync());
        }

        public async Task<IList<DeckListDto>> GetByUserAsync(Guid userId)
        {
            using var unitOfWork = unitOfWorkProvider.Create();
            var deckGetByUserQuery = deckGetByUserQueryFactory();
            deckGetByUserQuery.UserId = userId;

            return await deckGetByUserQuery.ExecuteAsync();
        }
    }
}