using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arcomage.Unity.Shared.Scripts
{
    public class CompositeObservable : Observable
    {
        private readonly Observable[] observableCollection;

        public CompositeObservable(params Observable[] observableCollection)
        {
            this.observableCollection = observableCollection;
        }

        public override void Update()
        {
            Array.ForEach(observableCollection, o => o.Update());
        }
    }
}