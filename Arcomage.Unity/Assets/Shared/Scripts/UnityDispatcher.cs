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

        public void Invoke(Action action)
        {
            executionQueue.Enqueue(action);
        }

        public void Invoke<T>(Action<T> action, T obj)
        {
            executionQueue.Enqueue(() => action(obj));
        }

        public Action<T> Invoke<T>(Action<T> action)
        {
            return a => Invoke(action, a);
        }
    }
}
