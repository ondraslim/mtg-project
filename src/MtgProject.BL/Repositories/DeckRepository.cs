using DAL.Common.Entities;
using DAL.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EntityFramework.Repository;

namespace BusinessLayer.Repositories
{
    public class DeckRepository : AppEntityFrameworkRepository<DeckEntity, Guid>
    {

        public DeckRepository(EntityFrameworkUnitOfWorkProvider entityFrameworkUnitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(entityFrameworkUnitOfWorkProvider, dateTimeProvider)
        {
        }

        public Task<List<DeckEntity>> GetAllAsync()
        {
            return Context.Decks.ToListAsync();
        }

        public Task<List<DeckEntity>> GetDecksOfUserAsync(Guid userId)
        {
            return Context.Decks.Where(d => d.UserId == userId).ToListAsync();
        }
    }
}