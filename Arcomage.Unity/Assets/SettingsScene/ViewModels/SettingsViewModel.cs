using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.SettingsScene.ViewModels
{
    public class SettingsViewModel
    {
        public DeckListViewModel DeckList { get; set; }

        public RuleListViewModel RuleList { get; set; }

        public SingleSettings Settings { get; set; }
    }
}
