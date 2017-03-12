using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;

namespace Arcomage.WebApi
{
    public class WebApiConfiguration
    {
        public void Configure(IAppBuilder app, IContainer container)
        {
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseWebApi(httpConfiguration);
        }
    }
}