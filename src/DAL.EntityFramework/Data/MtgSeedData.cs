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
                    Decks = new List<DeckEntity>
                    {
                        new DeckEntity
                        {
                            Created = new DateTime(2019, 07, 01),
                            Id = firstDeckId,
                            Name = "René Deck 1"
                        },
                        new DeckEntity
                        {
                            Created = new DateTime(2019, 07, 22),
                            Id = secondDeckId,
                            Name = "René Deck 2"
                        }
                    }
                },
                new UserEntity
                {
                    Created = new DateTime(2018, 07, 01),
                    Id = secondUserId,
                    Name = "Rudolf",
                    Decks = new List<DeckEntity>
                    {
                        new DeckEntity
                        {
                            Created = new DateTime(2019, 07, 01),
                            Id = thirdDeckId,
                            Name = "Rudolf Deck 1"
                        }
                    }
                }
            );

            modelBuilder.Entity<GameEntity>().HasData(
                new GameEntity
                {
                    Created = new DateTime(2019, 07, 01),
                    Id = Guid.NewGuid(),
                    StartingHp = 40,
                    TurnCount = 11,
                    GameParticipations = new List<GameParticipationEntity>
                    {
                        new GameParticipationEntity
                        {
                            Created = new DateTime(2019, 07, 01),
                            DeckId = firstDeckId,
                            UserId = firstUserId,
                            IsWinner = false,
                            Id = Guid.NewGuid(),
                            StatsEntity = new StatsEntity
                            {
                                Created = new DateTime(2019, 07, 01),
                                DamageDealt = 22,
                                DamageReceived = 49,
                                Id = Guid.NewGuid(),
                                Kills = 0
                            }
                        },
                        new GameParticipationEntity
                        {
                            Created = new DateTime(2019, 07, 01),
                            DeckId = thirdDeckId,
                            UserId = secondUserId,
                            IsWinner = true,
                            Id = Guid.NewGuid(),
                            StatsEntity = new StatsEntity
                            {
                                Created = new DateTime(2019, 07, 01),
                                DamageDealt = 49,
                                DamageReceived = 22,
                                Id = Guid.NewGuid(),
                                Kills = 1
                            }
                        }
                    }
                },
                new GameEntity
                {
                    Created = new DateTime(2019, 07, 22),
                    Id = Guid.NewGuid(),
                    StartingHp = 40,
                    TurnCount = 8,
                    GameParticipations = new List<GameParticipationEntity>
                    {
                        new GameParticipationEntity
                        {
                            Created = new DateTime(2019, 07, 22),
                            DeckId = secondDeckId,
                            UserId = firstUserId,
                            IsWinner = true,
                            Id = Guid.NewGuid(),
                            StatsEntity = new StatsEntity
                            {
                                Created = new DateTime(2019, 07, 22),
                                DamageDealt = 88,
                                DamageReceived = 11,
                                Id = Guid.NewGuid(),
                                Kills = 1
                            }
                        },
                        new GameParticipationEntity
                        {
                            Created = new DateTime(2019, 07, 22),
                            DeckId = thirdDeckId,
                            UserId = secondUserId,
                            IsWinner = false,
                            Id = Guid.NewGuid(),
                            StatsEntity = new StatsEntity
                            {
                                Created = new DateTime(2019, 07, 22),
                                DamageDealt = 11,
                                DamageReceived = 88,
                                Id = Guid.NewGuid(),
                                Kills = 0
                            }
                        }
                    }
                }
            );
        }
    }
}