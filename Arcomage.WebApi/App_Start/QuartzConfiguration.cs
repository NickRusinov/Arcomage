using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Network.Quartz;
using Arcomage.Network.Quartz.BackgroundJobs;
using Arcomage.WebApi.Infrastructure;
using Autofac;
using CrystalQuartz.Owin;
using NLog;
using Owin;
using Quartz;
using Quartz.Spi;

namespace Arcomage.WebApi
{
    /// <summary>
    /// Конфигурация планировщика задач <see cref="IScheduler"/>
    /// </summary>
    public class QuartzConfiguration
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Выполняет конфигурацию планировщика задач
        /// </summary>
        /// <param name="app">Owin приложение</param>
        /// <param name="container">Контейнер внедрения зависимостей</param>
        /// <returns>Задача, представляющая выполнение конфигурации</returns>
        public async Task Configure(IAppBuilder app, IContainer container)
        {
            logger.Info("Конфигурация планировщика задач Quartz");

            var scheduler = container.Resolve<IScheduler>();
            scheduler.JobFactory = container.Resolve<IJobFactory>();
            scheduler.ListenerManager.AddJobListener(new NLogJobListener("JobListener"));
            scheduler.ListenerManager.AddTriggerListener(new NLogTriggerListener("TriggerListener"));
            scheduler.ListenerManager.AddSchedulerListener(new NLogSchedulerListener());

            var createGameJobKey = QuartzKeyGenerator.JobForCreateGame();
            var createGameTriggerKey = QuartzKeyGenerator.TriggerForCreateGame();
            
            if (!await scheduler.CheckExists(createGameJobKey) && !await scheduler.CheckExists(createGameTriggerKey))
            {
                var createGameJob = JobBuilder.Create<CreateGameBackgroundJob>().WithIdentity(createGameJobKey)
                    .Build();
                var createGameTrigger = TriggerBuilder.Create().WithIdentity(createGameTriggerKey)
                    .WithSimpleSchedule(b => b.WithIntervalInSeconds(30).RepeatForever()).StartNow()
                    .Build();

                await scheduler.ScheduleJob(createGameJob, createGameTrigger);
            }

            await scheduler.Start();

            app.UseCrystalQuartz(scheduler);
        }
    }
}
