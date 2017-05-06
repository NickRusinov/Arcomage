using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Framework.Bindings
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

                Init?.Invoke();

                return;
            }

            Changed?.Invoke();
        }
        
        public event Action Changed;
        
        public event Action Init;
    }
}
