using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Decks;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.SettingsScene.ViewModels
{
    public class DeckViewModel
    {
        public DeckInfo DeckInfo { get; set; }

        public SingleSettings Settings { get; set; }
    }
}
