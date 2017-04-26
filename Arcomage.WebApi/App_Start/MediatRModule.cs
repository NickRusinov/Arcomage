using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using MediatR;

namespace Arcomage.WebApi
{
    public class MediatRModule : Module
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

            SingleInstanceFactory BuildSingleInstanceFactory(IComponentContext c) =>
                t => c.ResolveOptional(t);

            MultiInstanceFactory BuildMultiInstanceFactory(IComponentContext c) =>
                t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
        }
    }
}