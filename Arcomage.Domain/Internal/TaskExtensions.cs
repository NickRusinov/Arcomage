using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcomage.Domain.Internal
{
    internal static class TaskExtensions
    {
        public static Task Delay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<object>();
            var timer = new Timer(_ => tcs.SetResult(null));
            
            timer.Change(milliseconds, -1);

            return tcs.Task;
        }
    }
}
