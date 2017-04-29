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
            builder.Register(c => new Mediator(
                    BuildSingleInstanceFactory(c.Resolve<IComponentContext>()),
                    BuildMultiInstanceFactory(c.Resolve<IComponentContext>())))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
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
