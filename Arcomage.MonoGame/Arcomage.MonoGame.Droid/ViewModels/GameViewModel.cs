using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertyChanged;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    [ImplementPropertyChanged]
    public class GameViewModel : PageViewModel
    {
        public ResourcesViewModel ResourcesLeft { get; set; }

        public ResourcesViewModel ResourcesRight { get; set; }

        public BuildingsViewModel BuildingsLeft { get; set; }

        public BuildingsViewModel BuildingsRight { get; set; }

        public HandViewModel Hand { get; set; }

        public HistoryViewModel History { get; set; }
    }
}
