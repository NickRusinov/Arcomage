using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Features.ResolveAnything;
using Owin;

namespace Arcomage.WebApi
{
    public class AutofacConfiguration
    {
        public IContainer Configure(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}