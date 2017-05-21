using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Arcomage.Network.Jobs;
using Autofac;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    public class HangfireConfiguration
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public void Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация Hangfire");

            GlobalConfiguration.Configuration
                .UseStorage(new PostgreSqlStorage("ApplicationConnectionString"))
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

            BackgroundJob.Schedule<CreateGameJob>(j => j.Start(), TimeSpan.FromSeconds(30));
        }
    }
}