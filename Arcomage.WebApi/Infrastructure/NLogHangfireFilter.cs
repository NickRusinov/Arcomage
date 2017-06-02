using System;
using System.Collections.Generic;
using System.Linq;
using Hangfire.Client;
using Hangfire.Common;
using Hangfire.Server;
using Hangfire.States;
using Hangfire.Storage;
using NLog;

namespace Arcomage.WebApi.Infrastructure
{
    /// <summary>
    /// Выполняет логирование всех задач, исполняемых через <see cref="Hangfire"/>
    /// </summary>
    public class NLogHangfireFilter : JobFilterAttribute, IClientFilter, IServerFilter, IElectStateFilter, 
        IApplyStateFilter
    {
        /// <summary>
        /// Логгер
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// Выполняет логирование перед созданием задачи
        /// </summary>
        /// <param name="filterContext">Контекст задачи</param>
        public void OnCreating(CreatingContext filterContext)
        {
            logger.Info("Создание задачи типа {0}", filterContext.Job?.Type.Name ?? "n\a");
        }

        /// <summary>
        /// Выполняет логирование после создания задачи
        /// </summary>
        /// <param name="filterContext">Контекст задачи</param>
        public void OnCreated(CreatedContext filterContext)
        {
            logger.Info("Создана задача {0} типа {1}", filterContext.BackgroundJob?.Id ?? "n\a", 
                filterContext.BackgroundJob?.Job?.Type.Name ?? "n\a");
        }

        /// <summary>
        /// Выполняет логирование перед выполнением задачи
        /// </summary>
        /// <param name="filterContext">Контест задачи</param>
        public void OnPerforming(PerformingContext filterContext)
        {
            logger.Info("Начало выполнения задачи {0} типа {1}", filterContext.BackgroundJob?.Id ?? "n\a", 
                filterContext.BackgroundJob?.Job?.Type.Name ?? "n\a");
        }

        /// <summary>
        /// Выполняет логирование после выполнения задачи
        /// </summary>
        /// <param name="filterContext">Контекст задачи</param>
        public void OnPerformed(PerformedContext filterContext)
        {
            logger.Info("Завершение выполнения задачи {0} типа {1}", filterContext.BackgroundJob?.Id ?? "n\a",
                filterContext.BackgroundJob?.Job?.Type.Name ?? "n\a");
        }

        /// <summary>
        /// Выполняет логирование изменения состояния задачи
        /// </summary>
        /// <param name="filterContext">Контекст задачи</param>
        /// <param name="transaction">Транзакция исполнения задачи</param>
        public void OnStateApplied(ApplyStateContext filterContext, IWriteOnlyTransaction transaction)
        {
            logger.Info("Состояние задачи {0} типа {1} было изменено с {2} на {3}", 
                filterContext.BackgroundJob?.Id ?? "n\a", filterContext.BackgroundJob?.Job?.Type.Name ?? "n\a", 
                filterContext.OldStateName, filterContext.NewState.Name);
        }

        /// <summary>
        /// Выполняет логирование отмены состояния задачи
        /// </summary>
        /// <param name="filterContext">Контекст задачи</param>
        /// <param name="transaction">Транзакция исполнения задачи</param>
        public void OnStateUnapplied(ApplyStateContext filterContext, IWriteOnlyTransaction transaction)
        {
            logger.Info("Состояния задачи {0} типа {1} было отменено с {2}", filterContext.BackgroundJob?.Id ?? "n\a", 
                filterContext.BackgroundJob?.Job?.Type.Name ?? "n\a", filterContext.OldStateName);
        }

        /// <summary>
        /// Выполняет логирование исключений, выброшенных во время исполнения задачи
        /// </summary>
        /// <param name="filterContext">Контекст задачи</param>
        public void OnStateElection(ElectStateContext filterContext)
        {
            if (filterContext.CandidateState is FailedState failedState)
            {
                logger.Warn(failedState.Exception, "Произошло исключение при выполнении задачи {0} типа {1}",
                    filterContext.BackgroundJob?.Id ?? "n\a", filterContext.BackgroundJob?.Job?.Type.Name ?? "n\a");
            }
        }
    }
}
