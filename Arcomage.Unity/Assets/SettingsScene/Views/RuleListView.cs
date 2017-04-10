using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.SettingsScene.Scripts;
using Arcomage.Unity.SettingsScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class RuleListView : View<RuleListViewModel>
    {
        [Tooltip("Фабрика для создания объектов выбора правил")]
        public RuleFactory RuleFactory;

        protected override void OnViewModel(RuleListViewModel viewModel)
        {
            foreach (var ruleViewModel in viewModel.RuleCollection)
                RuleFactory.CreateRule(transform, ruleViewModel);
        }
    }
}
