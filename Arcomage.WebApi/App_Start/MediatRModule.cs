using System;
using System.Collections.Generic;
using System.Linq;
using Arcomage.WebApi.Infrastructure;
using Autofac;
using MediatR;

namespace Arcomage.WebApi
{
    public class MediatRModule : ApplicationModule
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.Register(c => BuildSingleInstanceFactory(c.Resolve<IComponentContext>()))
                .InstancePerLifetimeScope();

            builder.Register(c => BuildMultiInstanceFactory(c.Resolve<IComponentContext>()))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly, NetworkAssembly, NetworkPostgreSqlAssembly)
                .Where(t => t.Name.EndsWith("RequestHandler") || t.Name.EndsWith("NotificationHandler"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // TODO Автоматическая регистрация PipelineBehavior
            builder.RegisterGeneric(typeof(NLogPipelineBehavior<,>))
                .AsImplementedInterfaces()
                .SingleInstance();

            SingleInstanceFactory BuildSingleInstanceFactory(IComponentContext c) =>
                t => c.ResolveOptional(t);

            MultiInstanceFactory BuildMultiInstanceFactory(IComponentContext c) =>
                t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
        }
    }
}
