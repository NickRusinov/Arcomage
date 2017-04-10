using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Rules;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.SettingsScene.ViewModels
{
    public class RuleViewModel
    {
        public ClassicRuleInfo RuleInfo { get; set; }

        public SingleSettings Settings { get; set; }
    }
}
