using System;
using System.Collections.Generic;
using System.Linq;
using Arcomage.Network.Hangfire.BackgroundJobs;
using Arcomage.WebApi.Infrastructure;
using Autofac;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.PostgreSql;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    /// <summary>
    /// Конфигурация Hangfire, выполняющая настройку хранилища задач и веб-интерфейса
    /// </summary>
    public class HangfireConfiguration
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Выполняет конфигурирование Hangfire
        /// </summary>
        /// <param name="app">Owin приложение</param>
        /// <param name="container">Контейнер внедрения зависимостей</param>
        public void Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация Hangfire");

            GlobalConfiguration.Configuration
                .UseStorage(new PostgreSqlStorage(WebConfig.ApplicationConnectionString))
                .UseAutofacActivator(container, false)
                .UseNLogLogProvider();

            GlobalJobFilters.Filters
                .Add(new NLogHangfireFilter());

            var options = new DashboardOptions();
            
            if (WebConfig.HangfireDashboardUserName != null && WebConfig.HangfireDashboardUserPassword != null)
            {
                var authorizationUser = new BasicAuthAuthorizationUser();
                authorizationUser.Login = WebConfig.HangfireDashboardUserName;
                authorizationUser.PasswordClear = WebConfig.HangfireDashboardUserPassword;

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

            var scheduledJobs = JobStorage.Current.GetMonitoringApi().ScheduledJobs(0, int.MaxValue);
            var processingJobs = JobStorage.Current.GetMonitoringApi().ProcessingJobs(0, int.MaxValue);
            var enqueuedJobs = JobStorage.Current.GetMonitoringApi().EnqueuedJobs("default", 0, int.MaxValue);
            
            //JobStorage.Current.GetMonitoringApi().ProcessingJobs(0, int.MaxValue)
            //    .ForEach(p => BackgroundJob.Requeue(p.Key));

            if (!scheduledJobs.Any(p => p.Value.Job?.Type == typeof(CreateGameBackgroundJob)) &&
                !processingJobs.Any(p => p.Value.Job?.Type == typeof(CreateGameBackgroundJob)) &&
                !enqueuedJobs.Any(p => p.Value.Job?.Type == typeof(CreateGameBackgroundJob)))
            {
                BackgroundJob.Enqueue<CreateGameBackgroundJob>(j => j.Start());
            }
        }
    }
}
