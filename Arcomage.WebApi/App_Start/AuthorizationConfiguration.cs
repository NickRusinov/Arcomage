using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    public class AuthorizationConfiguration
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация авторизации");

            app.Use<UnityAuthorizationMiddleware>(container);
            app.Use<AndroidAuthorizationMiddleware>(container);
        }
    }
}