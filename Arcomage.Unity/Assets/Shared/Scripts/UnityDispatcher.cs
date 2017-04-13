using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public class UnityDispatcher : MonoBehaviour
    {
        private readonly ConcurrentQueue<Action> executionQueue =
            new ConcurrentQueue<Action>();

        public void Update()
        {
            Action action;
            while (executionQueue.TryDequeue(out action))
                action.Invoke();
        }

        public void Dispatch(Action action)
        {
            executionQueue.Enqueue(action);
        }

        public void Dispatch<T>(Action<T> action, T obj)
        {
            executionQueue.Enqueue(() => action(obj));
        }

        public Action Invoke(Action action)
        {
            return () => Dispatch(action);
        }

        public Action<T> Invoke<T>(Action<T> action)
        {
            return a => Dispatch(action, a);
        }
    }
}
