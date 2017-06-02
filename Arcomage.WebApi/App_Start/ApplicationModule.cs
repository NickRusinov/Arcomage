using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static System.Reflection.Assembly;

namespace Arcomage.WebApi
{
    public abstract class ApplicationModule : Autofac.Module
    {
        protected override Assembly ThisAssembly => GetExecutingAssembly();

        protected Assembly DomainAssembly => Assembly.Load("Arcomage.Domain");

        protected Assembly NetworkAssembly => Assembly.Load("Arcomage.Network");

        protected Assembly NetworkHangfireAssembly => Assembly.Load("Arcomage.Network.Hangfire");

        protected Assembly NetworkMigrationsAssembly => Assembly.Load("Arcomage.Network.Migrations");

        protected Assembly NetworkPostgreSqlAssembly => Assembly.Load("Arcomage.Network.PostgreSql");
    }
}
