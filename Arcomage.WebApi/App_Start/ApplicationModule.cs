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

        public static Assembly DomainAssembly => Assembly.Load("Arcomage.Domain");

        public static Assembly NetworkAssembly => Assembly.Load("Arcomage.Network");

        public static Assembly NetworkQuartzAssembly => Assembly.Load("Arcomage.Network.Quartz");

        public static Assembly NetworkMigrationsAssembly => Assembly.Load("Arcomage.Network.Migrations");

        public static Assembly NetworkPostgreSqlAssembly => Assembly.Load("Arcomage.Network.PostgreSql");
    }
}
