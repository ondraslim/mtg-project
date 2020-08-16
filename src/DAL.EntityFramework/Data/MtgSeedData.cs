using DAL.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DAL.EntityFramework.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var firstUserId = Guid.NewGuid();
            var secondUserId = Guid.NewGuid();

            var firstDeckId = Guid.NewGuid();
            var secondDeckId = Guid.NewGuid();
            var thirdDeckId = Guid.NewGuid();

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Created = new DateTime(2019, 07, 01),
                    Id = firstUserId,
                    Name = "René",
                    PasswordHash = ""
                },
                new UserEntity
                {
                    Created = new DateTime(2018, 07, 01),
                    Id = secondUserId,
                    Name = "Rudolf",
                    PasswordHash = ""
                }
            );

            modelBuilder.Entity<DeckEntity>().HasData(
                new DeckEntity
                {
                    Created = new DateTime(2019, 07, 01),
                    Id = firstDeckId,
                    UserId = firstUserId,
                    Name = "René Deck 1"
                },
                new DeckEntity
                {
                    Created = new DateTime(2019, 07, 22),
                    Id = secondDeckId,
                    UserId = firstUserId,
                    Name = "René Deck 2"
                },
                new DeckEntity
                {
                    Created = new DateTime(2019, 07, 01),
                    Id = thirdDeckId,
                    UserId = secondUserId,
                    Name = "Rudolf Deck 1"
                }
            );

            var firstGameId = Guid.NewGuid();
            var secondGameId = Guid.NewGuid();
            modelBuilder.Entity<GameEntity>().HasData(
                new GameEntity
                {
                    Created = new DateTime(2019, 07, 01),
                    Id = firstGameId,
                    StartingHp = 40,
                    TurnCount = 11
                },
                new GameEntity
                {
                    Created = new DateTime(2019, 07, 22),
                    Id = secondGameId,
                    StartingHp = 40,
                    TurnCount = 8
                }
            );

            var firstGameFirstParticipantId = Guid.NewGuid();
            var firstGameSecondParticipantId = Guid.NewGuid();
            var secondGameFirstParticipantId = Guid.NewGuid();
            var secondGameSecondParticipantId = Guid.NewGuid();

            modelBuilder.Entity<GameParticipationEntity>().HasData(
                new GameParticipationEntity
                {
                    Created = new DateTime(2019, 07, 01),
                    GameId = firstGameId,
                    DeckId = firstDeckId,
                    UserId = firstUserId,
                    IsWinner = false,
                    Id = firstGameFirstParticipantId
                },
                new GameParticipationEntity
                {
                    Created = new DateTime(2019, 07, 01),
                    DeckId = thirdDeckId,
                    GameId = firstGameId,
                    UserId = secondUserId,
                    IsWinner = true,
                    Id = firstGameSecondParticipantId
                },
                new GameParticipationEntity
                {
                    Created = new DateTime(2019, 07, 22),
                    DeckId = secondDeckId,
                    GameId = secondGameId,
                    UserId = firstUserId,
                    IsWinner = true,
                    Id = secondGameFirstParticipantId
                },
                new GameParticipationEntity
                {
                    Created = new DateTime(2019, 07, 22),
                    DeckId = thirdDeckId,
                    GameId = secondGameId,
                    UserId = secondUserId,
                    IsWinner = false,
                    Id = secondGameSecondParticipantId
                }
            );

            modelBuilder.Entity<StatsEntity>().HasData(
                new StatsEntity
                {
                    Created = new DateTime(2019, 07, 01),
                    DamageDealt = 22,
                    DamageReceived = 49,
                    Id = Guid.NewGuid(),
                    GameParticipationEntityId = firstGameFirstParticipantId,
                    Kills = 0
                },
                new StatsEntity
                {
                    Created = new DateTime(2019, 07, 01),
                    DamageDealt = 49,
                    DamageReceived = 22,
                    Id = Guid.NewGuid(),
                    GameParticipationEntityId = firstGameSecondParticipantId,
                    Kills = 1
                },
                new StatsEntity
                {
                    Created = new DateTime(2019, 07, 22),
                    DamageDealt = 88,
                    DamageReceived = 11,
                    Id = Guid.NewGuid(),
                    GameParticipationEntityId = secondGameFirstParticipantId,
                    Kills = 1
                },
                new StatsEntity
                {
                    Created = new DateTime(2019, 07, 22),
                    DamageDealt = 11,
                    DamageReceived = 88,
                    Id = Guid.NewGuid(),
                    GameParticipationEntityId = secondGameSecondParticipantId,
                    Kills = 0
                }
            );
        }
    }
}