using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    public class GameViewModel : ViewModel
    {
        public ResourcesViewModel ResourcesLeft { get; set; }

        public ResourcesViewModel ResourcesRight { get; set; }

        public BuildingsViewModel BuildingsLeft { get; set; }

        public BuildingsViewModel BuildingsRight { get; set; }

        public CardSetViewModel CardSet { get; set; }
    }
}
