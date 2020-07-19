using BusinessLayer.DTOs.Stats;
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
    public class GameParticipationRepository : EntityFrameworkRepository<GameParticipation, Guid>
    {
        public GameParticipationRepository(MtgDbContext dbContext)
            : base(dbContext)
        {
        }

        public Task<List<StatsDetailDto>> GetUsersBasedOnWinCountAsync()
        {
            return DbContext.Set<GameParticipation>()
                .GroupBy(gameParticipant => new {gameParticipant.UserId, gameParticipant.User.Name})
                .Select(gameCounts => new StatsDetailDto
                    {
                        Id = gameCounts.Key.UserId,
                        Name = gameCounts.Key.Name,
                        GameCount = gameCounts.Count(),
                        WinCount = gameCounts.Sum(participant => participant.IsWinner ? 1 : 0),
                        WinRatio = gameCounts.Sum(participant => participant.IsWinner ? 1 : 0) /
                                   (double) gameCounts.Count()
                    }
                )
                .OrderByDescending(us => us.WinCount)
                .ThenByDescending(us => us.GameCount)
                .Take(100)
                .ToListAsync();
        }
    }
}