﻿using AutoMapper;
using BusinessLayer.DTOs.GameParticipations;
using DAL.EntityFramework;
using DAL.EntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using DAL.Common.Entities;

namespace BusinessLayer.Repositories
{
    /*
    public class GameRepository : AppEntityFrameworkRepository<GameEntity, Guid>
    {
        private readonly IMapper _mapper;

        public GameRepository(IMapper mapper, MtgDbContext dbContext) : base(dbContext)
        {
            _mapper = mapper;
        }

        public object GetAllGameParticipationsOfGame(Guid gameId)
        {
            return _mapper.ProjectTo<GameParticipationCreateDto>(DbContext.GameParticipations
                .Include(g => g.User)
                .Include(g => g.Deck)
                .Include(g => g.Stats)
                .Where(g => g.Id == gameId))
                .ToListAsync();
        }
    }
    */
}