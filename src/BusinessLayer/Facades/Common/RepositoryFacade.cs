using AutoMapper;
using BusinessLayer.DTOs.Common;
using BusinessLayer.Services.Common;
using DAL.EntityFramework.Data;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessLayer.Facades.Common
{
    public class RepositoryFacade<TRepository, TEntity, TKey, TDto> : FacadeBase
        where TEntity : class, IEntity<TKey>, new()
        where TRepository : class, IRepository<TEntity, TKey>
        where TDto : BaseDto, new()
    {

        protected readonly RepositoryService<TRepository, TEntity, TKey> RepositoryService;

        public RepositoryFacade(
            EntityFrameworkUnitOfWorkProvider<MtgDbContext> unitOfWorkProvider,
            IMapper mapper,
            RepositoryService<TRepository, TEntity, TKey> repositoryService
            ) : base(unitOfWorkProvider, mapper)
        {
            RepositoryService = repositoryService;
        }

        public TKey Insert(TDto dto)
        {
            using var uow = UnitOfWorkProvider.Create();
            var entity = Mapper.Map<TEntity>(dto);
            RepositoryService.Insert(entity);
            return entity.Id;
        }

        public void Insert(IEnumerable<TDto> dtos)
        {
            using var uow = UnitOfWorkProvider.Create();
            RepositoryService.Insert(Mapper.ProjectTo<TEntity>(dtos.AsQueryable()));
        }

        public void Delete(TKey id)
        {
            using var uow = UnitOfWorkProvider.Create();
            RepositoryService.Delete(id);
        }

        public void Delete(TDto dto)
        {
            using var uow = UnitOfWorkProvider.Create();
            RepositoryService.Delete(Mapper.Map<TEntity>(dto));
        }

        public void Delete(IEnumerable<TEntity> dtos)
        {
            using var uow = UnitOfWorkProvider.Create();
            RepositoryService.Delete(Mapper.ProjectTo<TEntity>(dtos.AsQueryable()));
        }

        public void Delete(IEnumerable<TKey> ids)
        {
            using var uow = UnitOfWorkProvider.Create();
            RepositoryService.Delete(ids);
        }

        public TEntity GetById(TKey id)
        {
            using var uow = UnitOfWorkProvider.Create();
            return RepositoryService.GetById(id, new IIncludeDefinition<TEntity>[] { });
        }

        public Task<TEntity> GetByIdAsync(TKey id)
        {
            using var uow = UnitOfWorkProvider.Create();
            return RepositoryService.GetByIdAsync(id, new IIncludeDefinition<TEntity>[] { });
        }

        public Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken)
        {
            using var uow = UnitOfWorkProvider.Create();
            return RepositoryService.GetByIdAsync(cancellationToken, id, new IIncludeDefinition<TEntity>[] { });
        }

        public void Update(TKey id, TDto dto)
        {
            using var uow = UnitOfWorkProvider.Create();
            RepositoryService.Update(Mapper.Map<TEntity>(dto));
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            using var uow = UnitOfWorkProvider.Create();
            RepositoryService.Update(entities);
        }
    }
}