using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    public class CardViewModel : ViewModel
    {
        public string Identifier { get; set; }

        public string Resource { get; set; }

        public int Price { get; set; }

        public ICommand PlayCommand { get; set; }

        public ICommand DiscardCommand { get; set; }
    }
}
