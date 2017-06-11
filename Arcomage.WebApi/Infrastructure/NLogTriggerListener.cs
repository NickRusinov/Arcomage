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
    /// Выполняет логирование всех триггеров, выполняемых через <see cref="IScheduler"/>
    /// </summary>
    public class NLogTriggerListener : TriggerListenerSupport
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="NLogTriggerListener"/>
        /// </summary>
        /// <param name="name">Имя слушателя выполнения триггеров</param>
        public NLogTriggerListener(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Имя слушателя выполнения триггеров
        /// </summary>
        public override string Name { get; }

        /// <summary>
        /// Выполняет логирование вызова триггера
        /// </summary>
        /// <param name="trigger">Сработавший триггер</param>
        /// <param name="context">Контекст выполнения задачи</param>
        /// <returns>Задача, представляющая выполнения логирования</returns>
        public override Task TriggerFired(ITrigger trigger, IJobExecutionContext context)
        {
            logger.Debug("Триггер {0} вызвался для выполнения задачи {1} типа {2}", trigger.Key, trigger.JobKey,
                context.JobDetail.JobType.Name);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Выполняет логирование завершения триггера
        /// </summary>
        /// <param name="trigger">Завершенный триггер</param>
        /// <param name="context">Контекст выполнения задачи</param>
        /// <param name="triggerInstructionCode">Причина зарершения триггера</param>
        /// <returns>Задача, представляющая выполнения логирования</returns>
        public override Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, 
            SchedulerInstruction triggerInstructionCode)
        {
            logger.Debug("Триггер {0} завершился для выполнения задачи {1} типа {2}", trigger.Key, trigger.JobKey,
                context.JobDetail.JobType.Name);

            return Task.CompletedTask;
        }
    }
}
