using System;
using System.Collections.Generic;
using System.Linq;
using Arcomage.WebApi.Infrastructure;
using Autofac;
using Quartz;
using Quartz.Impl;

namespace Arcomage.WebApi
{
    public class QuartzModule : ApplicationModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(NetworkQuartzAssembly)
                .AssignableTo<IJob>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AutofacJobFactory>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<StdSchedulerFactory>()
                .UsingConstructor()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.Register(c => c.Resolve<ISchedulerFactory>().GetScheduler().GetAwaiter().GetResult())
                .SingleInstance();
        }
    }
}
