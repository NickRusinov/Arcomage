using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Framework;
using Arcomage.Unity.SettingsScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class RuleView : View<RuleViewModel>
    {
        [Tooltip("Текст для вывода названия правил")]
        public LocalizationScript NameText;

        [Tooltip("Текст для вывода описания правил")]
        public LocalizationScript DescriptionText;

        [Tooltip("Текст для вывода начального значения шахт")]
        public Text QuarryText;

        [Tooltip("Текст для вывода начального значения руды")]
        public Text BricksText;

        [Tooltip("Текст для вывода начального значения монастырей")]
        public Text MagicText;

        [Tooltip("Текст для вывода начального значения маны")]
        public Text GemsText;

        [Tooltip("Текст для вывода начального значения казарм")]
        public Text DungeonsText;

        [Tooltip("Текст для вывода начального значения отрядов")]
        public Text RecruitsText;

        [Tooltip("Текст для вывода начального значения высоты стены")]
        public Text WallText;

        [Tooltip("Текст для вывода начального значения высоты башни")]
        public Text TowerText;

        protected override void OnViewModel(RuleViewModel viewModel)
        {
            NameText.identifier = "Rule" + viewModel.RuleInfo.Identifier + "Name";
            DescriptionText.identifier = "Rule" + viewModel.RuleInfo.Identifier + "Description";
            DescriptionText.arguments = new[] { viewModel.RuleInfo.MaxTower.ToString(), viewModel.RuleInfo.MaxResources.ToString() };

            QuarryText.text = "+" + viewModel.RuleInfo.Quarry;
            BricksText.text = viewModel.RuleInfo.Bricks.ToString();
            MagicText.text = "+" + viewModel.RuleInfo.Magic;
            GemsText.text = viewModel.RuleInfo.Gems.ToString();
            DungeonsText.text = "+" + viewModel.RuleInfo.Dungeons;
            RecruitsText.text = viewModel.RuleInfo.Recruits.ToString();

            WallText.text = viewModel.RuleInfo.Wall.ToString();
            TowerText.text = viewModel.RuleInfo.Tower.ToString();
        }
    }
}
