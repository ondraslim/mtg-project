using Autofac;
using DAL.EntityFramework.Config;
using Module = Autofac.Module;

namespace BusinessLayer.Config
{
    public class BusinessLayerModule : Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule(new DALEntityFrameworkModule());

        }
    }
}