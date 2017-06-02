using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Npgsql;

namespace Arcomage.WebApi
{
    public class PostgresqlModule : ApplicationModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new NpgsqlConnection(WebConfig.ApplicationConnectionString))
                .OnActivating(ea => ea.Instance.Open())
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<NpgsqlConnection>().BeginTransaction())
                .OnRelease(t => { t.Commit(); t.Dispose(); })
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(NetworkPostgreSqlAssembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
