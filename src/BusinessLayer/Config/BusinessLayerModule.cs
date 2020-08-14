using Autofac;
using AutoMapper;
using BusinessLayer.Facades.Common;
using BusinessLayer.Services.Common;
using DAL.EntityFramework.Config;
using Module = Autofac.Module;

namespace BusinessLayer.Config
{
    public class BusinessLayerModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new DALEntityFrameworkModule());

            containerBuilder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IFacade>())
                .AsSelf()
                .InstancePerDependency();

            containerBuilder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsSelf()
                .InstancePerDependency();

            var config = new MapperConfiguration(cfg => cfg.AddMaps(ThisAssembly));
            containerBuilder.Register(p => new Mapper(config))
                .As<IMapper>()
                .SingleInstance();

        }
    }
}