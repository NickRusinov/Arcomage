using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class SettingsView : View
    {
        [Tooltip("Поле ввода имени первого игрока")]
        public InputField FirstPlayerInput;

        [Tooltip("Поле ввода имени второго игрока")]
        public InputField SecondPlayerInput;

        [Tooltip("Текст, выводящий название колоды")]
        public LocalizationScript DeckText;

        [Tooltip("Представление списка колод")]
        public DeckListView DeckListView;

        [Tooltip("Текст, выводящий название правил")]
        public LocalizationScript RuleText;

        [Tooltip("Представление списка правил")]
        public RuleListView RuleListView;

        public void Initialize()
        {
            DeckListView.Initialize();
            RuleListView.Initialize();

            Bind(Settings.Instance, s => s.FirstPlayer)
                .OnChangedAndInit(s => FirstPlayerInput.text = s);

            Bind(Settings.Instance, s => s.SecondPlayer)
                .OnChangedAndInit(s => SecondPlayerInput.text = s);

            Bind(Settings.Instance, s => s.Deck)
                .OnChangedAndInit(d => DeckText.identifier = "Deck" + d.Identifier + "Name");

            Bind(Settings.Instance, s => s.Rule)
                .OnChangedAndInit(r => RuleText.identifier = "Rule" + r.Identifier + "Name");

            FirstPlayerInput.onEndEdit
                .AddListener(s => Settings.Instance.FirstPlayer = s);

            SecondPlayerInput.onEndEdit
                .AddListener(s => Settings.Instance.SecondPlayer = s);
        }
    }
}
