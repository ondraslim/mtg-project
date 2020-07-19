using AutoMapper;
using BusinessLayer.DTOs.Decks;
using DAL.Common.Model;
using DAL.EntityFramework;
using DAL.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Repositories
{
    public class DeckRepository : EntityFrameworkRepository<Deck, Guid>
    {
        private readonly IMapper _mapper;

        public DeckRepository(IMapper mapper, MtgDbContext dbContext)
            : base(dbContext)
        {
            _mapper = mapper;
        }

        public Task<List<DeckListDto>> LisAllAsync()
        {
            return _mapper.ProjectTo<DeckListDto>(DbContext.Decks).ToListAsync();
        }

        public Task<List<DeckListDto>> GetDecksOfUserAsync(Guid userId)
        {
            return _mapper.ProjectTo<DeckListDto>(DbContext.Decks
                    .Where(d => d.UserId == userId))
                .ToListAsync();
        }
    }
}