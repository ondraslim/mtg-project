using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.EF.UnitOfWork
{
    public class EFUnitOfWork : Common.UnitOfWork.UnitOfWork
    {
        /// <summary>
        /// Gets the <see cref="DbContext"/>.
        /// </summary>
        public DbContext Context { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityFrameworkUnitOfWork"/> class.
        /// </summary>
        public EFUnitOfWork(Func<DbContext> dbContextFactory)
        {
            Context = dbContextFactory?.Invoke() ?? throw new ArgumentException("Db context factory can't be null!");
        }

        /// <summary>
        /// commits changes
        /// </summary>
        /// <returns></returns>
        protected override async Task CommitCore()
        {
            await Context.SaveChangesAsync();
        }

        public override void Dispose()
        {
            Context.Dispose();
        }
    }
}