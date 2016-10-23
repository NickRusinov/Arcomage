using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using PropertyChanged;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    [ImplementPropertyChanged]
    public class ButtonViewModel : ViewModel
    {
        public string Identifier { get; set; }

        public ICommand Command { get; set; }
    }
}