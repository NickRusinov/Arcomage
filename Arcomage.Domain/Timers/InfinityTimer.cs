using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.TimeSpan;
using static Arcomage.Domain.Extensions;

namespace Arcomage.Domain.Timers
{
    /// <summary>
    /// Таймер, представляющий бесконечный интервал времени
    /// </summary>
    [Serializable]
    public class InfinityTimer : Timer
    {
        /// <inheritdoc/>
        public override TimeSpan TimeRest => FromMilliseconds(-1);

        /// <inheritdoc/>
        public override Task Start(CancellationToken token)
        {
            return Delay(-1, token);
        }
    }
}
