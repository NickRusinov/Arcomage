using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.SettingsScene.ViewModels
{
    public class RuleListViewModel
    {
        public ICollection<RuleViewModel> RuleCollection { get; set; }

        public bool IsShow { get; set; }
    }
}
