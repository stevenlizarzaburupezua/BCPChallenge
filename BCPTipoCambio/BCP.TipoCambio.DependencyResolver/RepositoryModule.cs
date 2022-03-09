
using Autofac;
using BCP.Domain.Seedwork;
using BCP.Repository.Seedwork;
using BCP.TipoCambio.Domain.Interface.Repository;
using BCP.TipoCambio.Repository.Repositories;
using BCP.TipoCambio.Repository.UnitOfWork;

namespace BCP.TipoCambio.DependencyResolver
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWorkCore>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<SqlServerProcedureManager>().As<IStoreProcedureManager>().InstancePerLifetimeScope();
            builder.RegisterType<TipoCambioRepository>().As<ITipoCambioRepository>().InstancePerLifetimeScope();
        }
    }
}
