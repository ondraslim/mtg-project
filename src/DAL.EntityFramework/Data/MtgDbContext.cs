﻿using DAL_Common.Model;
using DAL_Common.Model.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DAL.EntityFramework.Data
{
    public class MtgDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<GameParticipation> GameParticipations { get; set; }


        public MtgDbContext(DbContextOptions<MtgDbContext> options) : base(options)
        {
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLoggerFactory(MyLoggerFactory);

        /// <summary>
        /// Commit your database changes asynchronously with onBeforeSaving operations
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Commit your database changes with onBeforeSaving operations
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <returns></returns>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict; //entities with relation will not be deleted.
            }

            modelBuilder.Entity<User>()
                .HasMany(u => u.Decks)
                .WithOne(d => d.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<GameParticipation>()
                .HasOne(cd => cd.Game)
                .WithMany(c => c.GameParticipations)
                .HasForeignKey(cd => cd.GameId);

            modelBuilder.Entity<GameParticipation>()
                .HasOne(cd => cd.User)
                .WithMany(c => c.GameParticipations)
                .HasForeignKey(cd => cd.UserId);


            modelBuilder.Entity<GameParticipation>()
                .HasOne(cd => cd.Deck)
                .WithMany(c => c.GameParticipations)
                .HasForeignKey(cd => cd.DeckId);

            base.OnModelCreating(modelBuilder);
        }
        

        #region helpers

        /// <summary>
        /// set the dates in entities
        /// </summary>
        private void OnBeforeSaving()
        {
            //select only entities which inherit from BaseEntity
            foreach (var entity in ChangeTracker.Entries<EntityChangeTracker>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        entity.Entity.Created = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entity.Entity.Modified = DateTime.UtcNow;
                        break;
                    case EntityState.Deleted:
                        entity.Entity.Deleted = DateTime.UtcNow;
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion
    }
}