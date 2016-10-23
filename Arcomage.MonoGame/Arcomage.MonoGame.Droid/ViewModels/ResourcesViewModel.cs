using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertyChanged;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    [ImplementPropertyChanged]
    public class ResourcesViewModel : ViewModel
    {
        public int Quarry { get; set; }

        public int Bricks { get; set; }

        public int Magic { get; set; }

        public int Gems { get; set; }

        public int Dungeons { get; set; }

        public int Recruits { get; set; }
    }
}
