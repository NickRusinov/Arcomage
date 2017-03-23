using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public sealed class ActionBinding<TSource> : Binding
    {
        private bool init;

        private readonly TSource source;

        private readonly Action<TSource> action;

        public ActionBinding(TSource source, Action<TSource> action)
        {
            this.source = source;
            this.action = action;
        }

        public override void Update()
        {
            action.Invoke(source);

            if (!init)
            {
                init = true;

                InvokeInit();

                return;
            }

            InvokeChanged();
        }

        private void InvokeChanged()
        {
            if (Changed != null)
                Changed.Invoke();
        }

        private void InvokeInit()
        {
            if (Init != null)
                Init.Invoke();
        }

#pragma warning disable 67
        public event Action Changed;
        
        public event Action Init;
#pragma warning restore 67
    }
}
