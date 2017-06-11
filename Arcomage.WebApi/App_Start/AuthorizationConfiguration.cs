using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    public class AuthorizationConfiguration
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Task Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация авторизации");

            app.Use<UnityAuthorizationMiddleware>(container);
            app.Use<AndroidAuthorizationMiddleware>(container);

            return Task.CompletedTask;
        }
    }
}
