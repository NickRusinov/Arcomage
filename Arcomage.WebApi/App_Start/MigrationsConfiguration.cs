using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors.Postgres;
using NLog;
using Owin;

namespace Arcomage.WebApi
{
    /// <summary>
    /// Конфигурация миграции базы данных, выполняющая актуализацию структуры базы данных
    /// </summary>
    public class MigrationsConfiguration
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Выполняет конфигурацию базы данных
        /// </summary>
        /// <param name="app">Owin приложение</param>
        /// <param name="container">Контейнер внедрения зависимостей</param>
        /// <returns>Задача, представляющая выполнение конфигурации</returns>
        public Task Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация миграции базы данных");

            var announcer = new TextWriterAnnouncer(logger.Info);
            announcer.ShowElapsedTime = true;
            announcer.ShowSql = true;
            
            var context = new RunnerContext(announcer);
            var factory = new PostgresProcessorFactory();
            var options = new MigrationProcessorOptions(false, 60, null);
            var processor = factory.Create(WebConfig.ApplicationConnectionString, announcer, options);
            var runner = new MigrationRunner(ApplicationModule.NetworkMigrationsAssembly, context, processor);

            runner.MigrateUp();

            return Task.CompletedTask;
        }

        /// <summary>
        /// Опции для выполнения миграции базы данных
        /// </summary>
        private class MigrationProcessorOptions : IMigrationProcessorOptions
        {
            public MigrationProcessorOptions(bool previewOnly, int timeout, string providerSwitch)
            {
                PreviewOnly = previewOnly;
                Timeout = timeout;
                ProviderSwitches = providerSwitch;
            }

            public bool PreviewOnly { get; set; }

            public int Timeout { get; set; }

            public string ProviderSwitches { get; set; }
        }
    }
}
