using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using PropertyChanged;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    [ImplementPropertyChanged]
    public class HistoryViewModel : ViewModel
    {
        public ObservableCollection<CardViewModel> CardCollection { get; set; }
    }
}