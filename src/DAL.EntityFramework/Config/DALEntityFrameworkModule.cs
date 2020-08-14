using Autofac;
using DAL.EntityFramework.Repository;
using Infrastructure.Common;
using Infrastructure.Common.Query;
using System;

namespace DAL.EntityFramework.Config
{
    public class DALEntityFrameworkModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .RegisterGeneric(typeof(AppEntityFrameworkRepository<,>))
                .As(typeof(IAppRepository<,>))
                .InstancePerDependency();

            // https://autofaccn.readthedocs.io/en/latest/resolve/relationships.html#supported-relationship-types
            containerBuilder
                .RegisterGeneric(typeof(IAppQuery<>))
                .As(typeof(IAppQuery<>))
                .InstancePerDependency();
        }
    }
}