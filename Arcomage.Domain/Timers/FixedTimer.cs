using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Timers
{
    /// <summary>
    /// Таймер, представляющий фиксированный заданный период времени
    /// </summary>
    [Serializable]
    public class FixedTimer : Timer
    {
        /// <summary>
        /// Фиксированный заданный период времени
        /// </summary>
        private readonly TimeSpan fixedPeriod;

        /// <summary>
        /// Инициализирует экземпляр класса <see cref="FixedTimer"/>
        /// </summary>
        /// <param name="fixedPeriod">Фиксированный заданный период времени</param>
        public FixedTimer(TimeSpan fixedPeriod)
        {
            this.fixedPeriod = fixedPeriod;
        }

        /// <inheritdoc/>
        public override Task Start(CancellationToken token)
        {
            return FrameworkExtensions.Delay(fixedPeriod, token);
        }
    }
}
