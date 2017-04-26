using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Owin;

namespace Arcomage.WebApi
{
    public class AuthorizationConfiguration
    {
        public void Configure(IAppBuilder app, IContainer container)
        {
            app.Use<UnityAuthorizationMiddleware>(container);
            app.Use<AndroidAuthorizationMiddleware>(container);
        }
    }
}