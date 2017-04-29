using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using Autofac;
using Autofac.Features.ResolveAnything;

namespace Arcomage.Unity.Configuration
{
    public class AutofacConfiguration
    {
        public IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            
            builder.RegisterType<Settings>()
                .SingleInstance();
            builder.Register(c => c.Resolve<Settings>().Single);
            builder.Register(c => c.Resolve<Settings>().Network);

            return builder.Build();
        }
    }
}
