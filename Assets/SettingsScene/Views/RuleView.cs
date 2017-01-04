using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class RuleView : View
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

        public void Initialize(RuleInfo ruleInfo)
        {
            NameText.identifier = "Rule" + ruleInfo.Identifier + "Name";
            DescriptionText.identifier = "Rule" + ruleInfo.Identifier + "Description";
            DescriptionText.arguments = ruleInfo.GetArguments();

            QuarryText.text = "+" + ruleInfo.Quarry;
            BricksText.text = ruleInfo.Bricks.ToString();
            MagicText.text = "+" + ruleInfo.Magic;
            GemsText.text = ruleInfo.Gems.ToString();
            DungeonsText.text = "+" + ruleInfo.Dungeons;
            RecruitsText.text = ruleInfo.Recruits.ToString();

            WallText.text = ruleInfo.Wall.ToString();
            TowerText.text = ruleInfo.Tower.ToString();
        }
    }
}
