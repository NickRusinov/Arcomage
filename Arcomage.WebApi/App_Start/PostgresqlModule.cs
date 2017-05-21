using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Npgsql;

namespace Arcomage.WebApi
{
    public class PostgresqlModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new NpgsqlConnection("ApplicationConnectionString"))
                .OnActivated(ea => ea.Instance.Open())
                .InstancePerLifetimeScope();

            builder.Register(c => c.Resolve<NpgsqlConnection>().BeginTransaction())
                .OnRelease(t => t.Commit())
                .OnRelease(t => t.Dispose())
                .InstancePerLifetimeScope();
        }
    }
}