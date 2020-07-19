using Autofac;
using Infrastructure.Common;

namespace DAL.EntityFramework.Config
{
    public class DALEntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterGeneric(typeof(EntityFrameworkRepository<,>))
                .As(typeof(IRepository<,>))
                .InstancePerDependency();
        }
    }
}