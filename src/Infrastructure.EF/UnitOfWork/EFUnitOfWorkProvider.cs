using Infrastructure.Common.UnitOfWork;
using Infrastructure.Common.UnitOfWork.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.UnitOfWork
{
    public class EFUnitOfWorkProvider : UnitOfWorkProvider
    {
        private readonly Func<DbContext> _dbContextFactory;

        public EFUnitOfWorkProvider(Func<DbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public override IUnitOfWork Create()
        {
            UowLocalInstance.Value = new EFUnitOfWork(_dbContextFactory);
            return UowLocalInstance.Value;
        }
    }
}