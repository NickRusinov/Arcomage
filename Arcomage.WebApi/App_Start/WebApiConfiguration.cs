using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using Autofac;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    public class WebApiConfiguration
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public Task Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация WebApi");

            var httpConfiguration = new HttpConfiguration();
            httpConfiguration.MapHttpAttributeRoutes();
            httpConfiguration.DependencyResolver = container.Resolve<IDependencyResolver>();

            var traceWriter = httpConfiguration.EnableSystemDiagnosticsTracing();
            traceWriter.TraceSource = new TraceSource("WebApi");

            app.UseWebApi(httpConfiguration);

            return Task.CompletedTask;
        }
    }
}