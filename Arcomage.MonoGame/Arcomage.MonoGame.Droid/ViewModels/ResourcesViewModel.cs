using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    public class ResourcesViewModel : ViewModel
    {
        public ResourceViewModel Bricks { get; set; }

        public ResourceViewModel Gems { get; set; }

        public ResourceViewModel Recruits { get; set; }
    }
}
