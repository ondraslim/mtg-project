using AutoMapper;
using BusinessLayer.DTOs.Decks;
using DAL.Common.Model;
using Microsoft.EntityFrameworkCore;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class DeckRepository : DAL.EntityFramework.EntityFrameworkRepository<DeckEntity, Guid>
    {
        private readonly IMapper mapper;

        public DeckRepository(EntityFrameworkUnitOfWorkProvider entityFrameworkUnitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(entityFrameworkUnitOfWorkProvider, dateTimeProvider)
        {
        }

        public async Task<IList<DeckEntity>> GetAllAsync()
        {
            return await Context.Decks.ToListAsync();
        }

        public Task<List<DeckListDto>> GetDecksOfUserAsync(Guid userId)
        {
            return mapper.ProjectTo<DeckListDto>(Context.Decks.Where(d => d.UserId == userId)).ToListAsync();
        }


    }
}