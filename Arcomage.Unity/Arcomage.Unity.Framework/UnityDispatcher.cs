using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Framework
{
    public class UnityDispatcher
    {
        private readonly Scene scene;

        public UnityDispatcher(Scene scene)
        {
            this.scene = scene;
        }

        public void Dispatch(Action action) => scene.StartCoroutine(action);

        public void Dispatch<T>(Action<T> action, T arg) => scene.StartCoroutine(action, arg);

        public Action Invoke(Action action) => () => Dispatch(action);

        public Action<T> Invoke<T>(Action<T> action) => a => Dispatch(action, a);
    }
}
