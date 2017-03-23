using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcomage.Domain.Timers
{
    /// <summary>
    /// Игровой таймер
    /// </summary>
    [Serializable]
    public abstract class Timer
    {
        /// <summary>
        /// Запускает игровой таймер. Возвращаемая задача завершается после истечения периода таймера или после 
        /// отмены указанного токена
        /// </summary>
        /// <param name="token">Токен завершения счета таймера</param>
        /// <returns>Задачу, представляющую периода таймера</returns>
        public abstract Task Start(CancellationToken token);
    }
}
