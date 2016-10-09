using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    public class BuildingsViewModel : ViewModel
    {
        public int Wall { get; set; }

        public int Tower { get; set; }

        public int MaxWall { get; set; }

        public int MaxTower { get; set; }
    }
}
