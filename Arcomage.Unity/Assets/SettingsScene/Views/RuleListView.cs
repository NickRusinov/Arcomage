using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Rules;
using Arcomage.Unity.SettingsScene.Factories;
using Arcomage.Unity.SettingsScene.Scripts;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class RuleListView : View
    {
        [Tooltip("Фабрика для создания объектов выбора правил")]
        public RuleFactory RuleFactory;

        public void Initialize()
        {
            RuleFactory.CreateRule(transform, new ClassicRuleInfo("EmpireCapital", 2, 5, 2, 5, 2, 5, 5, 20, 50, 150));
            RuleFactory.CreateRule(transform, new ClassicRuleInfo("TigersLake", 5, 25, 5, 25, 5, 25, 10, 20, 150, 400));
            RuleFactory.CreateRule(transform, new ClassicRuleInfo("EastRiver", 3, 5, 3, 5, 3, 5, 10, 20, 75, 200));
        }
    }
}
