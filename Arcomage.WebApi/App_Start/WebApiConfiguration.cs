using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Autofac;
using Owin;

namespace Arcomage.WebApi
{
    public class WebApiConfiguration
    {
        public void Configure(IAppBuilder app, IContainer container)
        {
            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.DependencyResolver = container.Resolve<IDependencyResolver>();

            var traceWriter = httpConfiguration.EnableSystemDiagnosticsTracing();
            traceWriter.TraceSource = new TraceSource("WebApi");

            app.UseWebApi(httpConfiguration);
        }
    }
}