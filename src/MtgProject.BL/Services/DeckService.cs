using BusinessLayer.Repositories;
using BusinessLayer.Services.Common;
using DAL.Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class DeckService : RepositoryService<DeckRepository, DeckEntity, Guid>
    {

        public DeckService(DeckRepository deckRepository) : base(deckRepository)
        {
        }


        public Task<List<DeckEntity>> GetAllAsync()
        {
            return Repository.GetAllAsync();
        }


        public Task<List<DeckEntity>> GetDecksAllByUserIdAsync(Guid userId)
        {
            return Repository.GetDecksOfUserAsync(userId);
        }

    }
}