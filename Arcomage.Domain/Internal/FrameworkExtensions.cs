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
        public static Task Delay(int milliseconds)
        {
            var tcs = new TaskCompletionSource<object>();
            var timer = new Timer(_ => tcs.SetResult(null));

            timer.Change(milliseconds, -1);

            return tcs.Task;
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
