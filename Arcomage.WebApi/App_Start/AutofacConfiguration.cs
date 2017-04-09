using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
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
            builder.Register(c => HttpContext.Current.GetOwinContext()).AsSelf();

            return builder.Build();
        }
    }
}