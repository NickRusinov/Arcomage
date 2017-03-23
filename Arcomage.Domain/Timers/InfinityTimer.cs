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
    /// Таймер, представляющий бесконечный интервал времени
    /// </summary>
    [Serializable]
    public class InfinityTimer : Timer
    {
        /// <inheritdoc/>
        public override Task Start(CancellationToken token)
        {
            return FrameworkExtensions.Delay(TimeSpan.FromMilliseconds(-1));
        }
    }
}
