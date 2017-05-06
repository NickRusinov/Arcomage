using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Framework
{
    public abstract class View<TViewModel> : View
    {
        private TViewModel viewModel;

        public TViewModel ViewModel
        {
            get => viewModel;
            set => OnViewModel(viewModel = value);
        }

        protected virtual void OnViewModel(TViewModel viewModel) { }
    }
}
