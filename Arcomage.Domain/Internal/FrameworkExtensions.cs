using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcomage.Domain.Internal
{
    internal static class FrameworkExtensions
    {
        public static Task CompletedTask()
        {
#if NET35
            return TaskEx.FromResult<object>(null);
#else
            return Task.CompletedTask;
#endif
        }

        public static Task<T> FromResult<T>(T result)
        {
#if NET35
            return TaskEx.FromResult(result);
#else
            return Task.FromResult(result);
#endif
        }

        public static Task Delay(TimeSpan period, CancellationToken token = default(CancellationToken))
        {
#if NET35
            return TaskEx.Delay(period, token);
#else
            return Task.Delay(period, token);
#endif
        }

        public static Task<T> DefaultIfCancel<T>(this Task<T> task, T @default = default(T))
        {
            return task.ContinueWith(t => t.Status == TaskStatus.Canceled ? @default : t.Result, 
                TaskContinuationOptions.ExecuteSynchronously);
        }

        public static Task CancelWhenAny(this CancellationTokenSource tokenSource, params Task[] tasks)
        {
            return Task.Factory.ContinueWhenAny(tasks, t => tokenSource.Cancel(),
                TaskContinuationOptions.ExecuteSynchronously);
        }

        public static T Copy<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);

                stream.Position = 0;

                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
