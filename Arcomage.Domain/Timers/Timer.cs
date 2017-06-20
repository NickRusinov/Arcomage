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
        /// Остаток времени до окончания периода таймера
        /// </summary>
        public abstract TimeSpan TimeRest { get; }

        /// <summary>
        /// Запускает игровой таймер. Возвращаемая задача завершается после истечения периода таймера или после 
        /// отмены указанного токена
        /// </summary>
        /// <param name="token">Токен завершения счета таймера</param>
        /// <returns>Задачу, представляющую периода таймера</returns>
        public abstract Task Start(CancellationToken token);

        /// <summary>
        /// Останавливает отсчет запущенного игрового таймера. После зстановки таймера, остаток времени 
        /// устанавливается в значение по умолчанию.
        /// </summary>
        public abstract void Reset();
    }
}
