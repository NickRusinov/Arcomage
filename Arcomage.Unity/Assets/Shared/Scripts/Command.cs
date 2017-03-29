using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Command<T>
    {
        public virtual Task Execute(T state)
        {
            return TaskEx.FromResult(default(object));
        }

        public virtual bool CanExecute(T state)
        {
            return true;
        }
    }

    public class Command<T, TResult>
    {
        public virtual Task<TResult> Execute(T state)
        {
            return TaskEx.FromResult(default(TResult));
        }

        public virtual bool CanExecute(T state)
        {
            return true;
        }
    }
}
