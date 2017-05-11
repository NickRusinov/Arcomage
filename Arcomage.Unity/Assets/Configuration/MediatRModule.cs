using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using MediatR;

namespace Arcomage.Unity.Configuration
{
    public class MediatRModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Mediator>()
                .As<IMediator>()
                .InstancePerLifetimeScope();

            builder.Register(c => BuildSingleInstanceFactory(c.Resolve<IComponentContext>()))
                .InstancePerLifetimeScope();

            builder.Register(c => BuildMultiInstanceFactory(c.Resolve<IComponentContext>()))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(t => t.Name.EndsWith("RequestHandler"))
                .AsImplementedInterfaces()
                .PreserveExistingDefaults();
        }

        private static SingleInstanceFactory BuildSingleInstanceFactory(IComponentContext context)
        {
            return t => context.Resolve(t);
        }

        private static MultiInstanceFactory BuildMultiInstanceFactory(IComponentContext context)
        {
            return t => ((IEnumerable)context.Resolve(typeof(IEnumerable<>).MakeGenericType(t))).Cast<object>();
        }
    }
}
