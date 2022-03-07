

using Autofac;
using BCP.TipoCambio.Application.Implementation;
using BCP.TipoCambio.Application.Interface;

namespace BCP.TipoCambio.DependencyResolver
{
    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TipoCambioService>().As<ITipoCambioService>().InstancePerLifetimeScope();
        }
    }
}
