using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Owin;
using Hangfire;
using Hangfire.MemoryStorage;

namespace Arcomage.WebApi
{
    public class HangfireConfiguration
    {
        public void Configure(IAppBuilder app, IContainer container)
        {
            GlobalConfiguration.Configuration
                //.UseSqlServerStorage("Data Source=(local);Initial Catalog=Arcomagic;Integrated Security=True")
                .UseStorage(new MemoryStorage())
                .UseAutofacActivator(container, false)
                .UseNLogLogProvider();

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}