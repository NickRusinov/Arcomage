using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Owin;
using Hangfire;
using Hangfire.MemoryStorage;
using Hangfire.Dashboard;
using System.Configuration;

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

            var options = new DashboardOptions();

            var userName = ConfigurationManager.AppSettings.Get("HangfireDashboardUserName");
            var userPassword = ConfigurationManager.AppSettings.Get("HangfireDashboardUserPassword");

            if (userName != null && userPassword != null)
            {
                var authorizationUser = new BasicAuthAuthorizationUser();
                authorizationUser.Login = userName;
                authorizationUser.PasswordClear = userPassword;

                var filterOptions = new BasicAuthAuthorizationFilterOptions();
                filterOptions.RequireSsl = false;
                filterOptions.SslRedirect = false;
                filterOptions.LoginCaseSensitive = true;
                filterOptions.Users = new[] { authorizationUser };

                var filter = new BasicAuthAuthorizationFilter(filterOptions);

#pragma warning disable CS0618 // Type or member is obsolete
                options.AuthorizationFilters = new[] { filter };
#pragma warning restore CS0618 // Type or member is obsolete
            }

            app.UseHangfireDashboard("/hangfire", options);
            app.UseHangfireServer();
        }
    }
}