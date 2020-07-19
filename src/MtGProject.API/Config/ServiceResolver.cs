using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using BusinessLayer.Config;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GraphQL.API.Config
{
    public class ServiceResolver
    {
        private static ContainerBuilder _containerBuilder;
        private static IServiceProvider _serviceProvider;

        public ServiceResolver(IServiceCollection services)
        {
            _containerBuilder = new ContainerBuilder();
            _containerBuilder.RegisterModule(new BusinessLayerModule());
            _containerBuilder.Populate(services);
            var container = _containerBuilder.Build();


#if DEBUG
            container.ResolveOperationBeginning += (sender, e) =>
            {
                IComponentRegistration registration = null;
                e.ResolveOperation.InstanceLookupBeginning += (sender2, e2) =>
                {
                    registration = e2.InstanceLookup.ComponentRegistration;
                };

                e.ResolveOperation.CurrentOperationEnding += (sender2, e2) =>
                {
                    if (e2.Exception == null) return;
                    
                    ConstructorInfo ci = registration.Activator.LimitType.GetConstructors().First();

                    var sb = new StringBuilder();
                    sb.AppendLine($"Can't instantiate {registration.Activator.LimitType}");

                    foreach (ParameterInfo pi in ci.GetParameters())
                    {
                        if (!((ILifetimeScope)sender).IsRegistered(pi.ParameterType))
                        {
                            sb.AppendLine($"\t{pi.ParameterType} {pi.Name} is not registered");
                        }
                    }

                    throw new DependencyResolutionException(sb.ToString(), e2.Exception);
                };
            };
#endif
            _serviceProvider = new AutofacServiceProvider(container);
        }

        public IServiceProvider GetServiceProvider()
        {
            return _serviceProvider;
        }
    }
}