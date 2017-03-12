using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Owin;

namespace Arcomage.WebApi
{
    public class AuthorizationConfiguration
    {
        public void Configure(IAppBuilder app, IContainer container)
        {
            app.Use<AuthorizationMiddleware>();
        }
    }
}