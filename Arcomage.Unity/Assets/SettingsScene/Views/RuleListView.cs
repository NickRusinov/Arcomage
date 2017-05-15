using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Framework;
using Arcomage.Unity.SettingsScene.Scripts;
using Arcomage.Unity.SettingsScene.ViewModels;
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

        private void OnEnable()
        {
            ViewModel.IsShow = true;
        }

        private void OnDisable()
        {
            ViewModel.IsShow = false;
        }
    }
}
