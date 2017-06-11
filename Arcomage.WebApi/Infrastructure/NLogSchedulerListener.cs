using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Quartz;
using Quartz.Listener;

namespace Arcomage.WebApi.Infrastructure
{
    /// <summary>
    /// Выполняет логирование планировщика задач <see cref="IScheduler"/>
    /// </summary>
    public class NLogSchedulerListener : SchedulerListenerSupport
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Выполняет логирование запуска планировщика задач
        /// </summary>
        /// <returns>Задача, представляющая выполнения логирования</returns>
        public override Task SchedulerStarted()
        {
            logger.Info("Планировщик задач запущен");

            return Task.CompletedTask;
        }

        /// <summary>
        /// Выполняет логирование остановки планировщика задач
        /// </summary>
        /// <returns>Задача, представляющая выполнения логирования</returns>
        public override Task SchedulerShutdown()
        {
            logger.Info("Планировщик задач остановлен");

            return Task.CompletedTask;
        }

        /// <summary>
        /// Выполняет логирование исключений планировщика задач
        /// </summary>
        /// <param name="msg">Сообщение об ошибке</param>
        /// <param name="cause">Возникшее исключение</param>
        /// <returns>Задача, представляющая выполнения логирования</returns>
        public override Task SchedulerError(string msg, SchedulerException cause)
        {
            logger.Warn(cause, "Планировщик задач завершил выполнение с ошибкой");

            return Task.CompletedTask;
        }
    }
}
