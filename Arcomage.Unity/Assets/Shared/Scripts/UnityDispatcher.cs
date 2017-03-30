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
        public static UnityDispatcher Instance { get; private set; }

        private readonly ConcurrentQueue<Action> executionQueue =
            new ConcurrentQueue<Action>();

        public void Awake()
        {
            Instance = this;
        }

        public void Update()
        {
            Action action;
            while (executionQueue.TryDequeue(out action))
                action.Invoke();
        }

        public static void Execute(Action action)
        {
            Instance.executionQueue.Enqueue(action);
        }

        public static void Execute<T>(Action<T> action, T obj)
        {
            Instance.executionQueue.Enqueue(() => action(obj));
        }

        public static Action<T> Dispatch<T>(Action<T> action)
        {
            return a => Instance.executionQueue.Enqueue(() => action(a));
        }
    }
}
