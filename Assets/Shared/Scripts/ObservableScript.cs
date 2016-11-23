using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public class ObservableScript : Script
    {
        private Observable observable = Observable.Instance;

        protected virtual void Initialize(params Observable[] observableCollection)
        {
            observable = new CompositeObservable(observableCollection);
        }
        
        public override void Update()
        {
            observable.Update();
        }
    }
}
