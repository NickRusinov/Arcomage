using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public class View : MonoBehaviour
    {
        private readonly List<Binding> bindingCollection = new List<Binding>();
        
        protected ValueBinding<TSource, TValue> Bind<TSource, TValue>(TSource source, Func<TSource, TValue> func)
        {
            var binding = new ValueBinding<TSource, TValue>(source, func);
            bindingCollection.Add(binding);

            return binding;
        }

        protected CollectionBinding<TSource, TValue> Bind<TSource, TValue>(TSource source, Func<TSource, IList<TValue>> func)
        {
            var binding = new CollectionBinding<TSource, TValue>(source, func);
            bindingCollection.Add(binding);

            return binding;
        }

        public virtual void Update()
        {
            bindingCollection.ForEach(b => b.Update());
        }
    }
}
