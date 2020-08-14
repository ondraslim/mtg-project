using AutoMapper;
using DAL.EntityFramework.Data;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace BusinessLayer.Facades.Common
{
    public class FacadeBase : IFacade
    {
        protected readonly EntityFrameworkUnitOfWorkProvider<MtgDbContext> UnitOfWorkProvider;
        protected readonly IMapper Mapper;

        public FacadeBase(EntityFrameworkUnitOfWorkProvider<MtgDbContext> unitOfWorkProvider, IMapper mapper)
        {
            UnitOfWorkProvider = unitOfWorkProvider;
            Mapper = mapper;
        }
    }
}