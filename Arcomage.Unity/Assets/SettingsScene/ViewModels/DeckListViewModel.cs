using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.SettingsScene.ViewModels
{
    public class DeckListViewModel
    {
        public ICollection<DeckViewModel> DeckCollection { get; set; }
    }
}
