using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    public class CardSetViewModel : ViewModel
    {
        public ObservableCollection<CardViewModel> CardCollection { get; set; }
    }
}
