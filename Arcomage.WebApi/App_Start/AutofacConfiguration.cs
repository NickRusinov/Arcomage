using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Features.ResolveAnything;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    public class AutofacConfiguration
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public IContainer Configure(IAppBuilder app)
        {
            logger.Info("Конфигурация Autofac");

            var builder = new ContainerBuilder();
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());
            builder.Register(c => HttpContext.Current.GetOwinContext()).AsSelf();

            return builder.Build();
        }
    }
}