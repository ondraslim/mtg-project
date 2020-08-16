using AutoMapper;
using AutoMapper.QueryableExtensions;
using DAL.EntityFramework.Data;
using Infrastructure.Common.Query;
using Microsoft.EntityFrameworkCore;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;
using System.Linq;

namespace DAL.EntityFramework.Query
{
    public abstract class AppEntityFrameworkQueryBase<TResult, TEntity, TKey> : EntityFrameworkQuery<TResult, MtgDbContext>, IAppQuery<TResult>
        where TEntity : class
    {
        private readonly IMapper mapper;

        protected AppEntityFrameworkQueryBase(
            IUnitOfWorkProvider unitOfWorkProvider,
            IMapper mapper)
            : base(unitOfWorkProvider)
        {
            this.mapper = mapper;
        }

        protected virtual IQueryable<TEntity> FilterQuery(IQueryable<TEntity> query)
        {
            return query;
        }

        //TODO: check new version of riganti infrastructure with includes -> might have better version for multi-llevel includes
        protected virtual IQueryable<TEntity> AddIncludes(DbSet<TEntity> dbset)
        {
            return dbset;
        }

        protected override IQueryable<TResult> GetQueryable()
        {
            return FilterQuery(AddIncludes(Context.Set<TEntity>())).ProjectTo<TResult>(mapper.ConfigurationProvider);
        }
    }
}