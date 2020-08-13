using System;
using DAL.EntityFramework.Data;
using Infrastructure.Common;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace DAL.EntityFramework
{
    public class AppEntityFrameworkUnitOfWorkProvider : EntityFrameworkUnitOfWorkProvider<MtgDbContext>, IAppUnitOfWorkProvider
    {
        public AppEntityFrameworkUnitOfWorkProvider(IUnitOfWorkRegistry registry, Func<MtgDbContext> dbContextFactory)
            : base(registry, dbContextFactory)
        {
        }
    }
}