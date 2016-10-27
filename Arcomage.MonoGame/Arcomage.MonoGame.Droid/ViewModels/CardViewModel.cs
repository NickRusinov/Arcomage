using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using PropertyChanged;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    [ImplementPropertyChanged]
    public class CardViewModel : ViewModel
    {
        public string Identifier { get; set; }

        public string Resource { get; set; }

        public int Price { get; set; }

        public int Index { get; set; }

        public bool CanPlay { get; set; }

        public bool CanDiscard { get; set; }

        public ICommand PlayCommand { get; set; }

        public ICommand DiscardCommand { get; set; }
    }
}
