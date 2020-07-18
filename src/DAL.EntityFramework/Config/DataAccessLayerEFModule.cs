using Autofac;
using Infrastructure.Common;
using Infrastructure.Common.Query;
using Infrastructure.Common.UnitOfWork.Interfaces;
using Infrastructure.EF;
using Infrastructure.EF.UnitOfWork;

namespace DAL.EntityFramework.Config
{
    public class DataAccessLayerEFModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<EFUnitOfWorkProvider>()
                .As<IUnitOfWorkProvider>()
                .SingleInstance();

            containerBuilder.RegisterGeneric(typeof(EFRepository<,>))
                .As(typeof(IRepository<,>))
                .InstancePerDependency();

            containerBuilder.RegisterGeneric(typeof(EFQuery<,>))
                .As(typeof(IQuery<,>))
                .InstancePerDependency();
        }
    }
}