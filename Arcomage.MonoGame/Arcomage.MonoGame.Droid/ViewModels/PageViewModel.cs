using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using PropertyChanged;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    [ImplementPropertyChanged]
    public class PageViewModel : ViewModel
    {
        public ICommand BackCommand { get; set; }

        public ICommand UpdateCommand { get; set; }
    }
}