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
    /// Выполняет логирование всех задач, выполняемых через <see cref="IScheduler"/>
    /// </summary>
    public class NLogJobListener : JobListenerSupport
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="NLogJobListener"/>
        /// </summary>
        /// <param name="name">Имя слушателя выполнения задач</param>
        public NLogJobListener(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Имя слушателя выполнения задач
        /// </summary>
        public override string Name { get; }
        
        /// <summary>
        /// Выполняет логирование начала выполнения задачи
        /// </summary>
        /// <param name="context">Контекст выполнения задачи</param>
        /// <returns>Задача, представляющая выполнение логирования</returns>
        public override Task JobToBeExecuted(IJobExecutionContext context)
        {
            logger.Debug("Задача {0} начала выполнение", context.JobDetail.JobType.Name);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Выполняет логирование завершение выполнения задачи
        /// </summary>
        /// <param name="context">Контекст выполнения задачи</param>
        /// <param name="jobException">Исключение, возникшее во время выполнения задачи</param>
        /// <returns>Задача, представляющая выполнение логирования</returns>
        public override Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException)
        {
            if (jobException == null)
            {
                logger.Debug("Задача {0} завершила выполнение с результатом {1}", context.JobDetail.JobType.Name,
                    context.Result ?? "<null>");
            }
            else
            {
                logger.Warn(jobException, "Задача {0} завершила выполнение с исключением", 
                    context.JobDetail.JobType.Name);
            }

            return Task.CompletedTask;
        }
    }
}
