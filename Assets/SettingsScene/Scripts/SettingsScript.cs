using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Scripts
{
    public class SettingsScript : View
    {
        [Tooltip("Поле ввода имени первого игрока")]
        public InputField FirstPlayerInput;

        [Tooltip("Поле ввода имени второго игрока")]
        public InputField SecondPlayerInput;

        [Tooltip("Список выбора правил игры")]
        public Dropdown RuleDropdown;

        [Tooltip("Список выбора колоды игры")]
        public Dropdown DeckDropdown;

        public void Initialize()
        {
            Bind(Settings.Instance, s => s.FirstPlayer)
                .OnChangedAndInit(s => FirstPlayerInput.text = s);

            Bind(Settings.Instance, s => s.SecondPlayer)
                .OnChangedAndInit(s => SecondPlayerInput.text = s);

            Bind(Settings.Instance, s => s.Rule)
                .OnChangedAndInit(s => RuleDropdown.value = RuleDropdown.options.FindIndex(d => d.text == s));

            Bind(Settings.Instance, s => s.Deck)
                .OnChangedAndInit(s => DeckDropdown.value = DeckDropdown.options.FindIndex(d => d.text == s));

            FirstPlayerInput.onEndEdit
                .AddListener(s => Settings.Instance.FirstPlayer = s);

            SecondPlayerInput.onEndEdit
                .AddListener(s => Settings.Instance.SecondPlayer = s);

            RuleDropdown.onValueChanged
                .AddListener(i => Settings.Instance.Rule = RuleDropdown.options[i].text);

            DeckDropdown.onValueChanged
                .AddListener(i => Settings.Instance.Deck = DeckDropdown.options[i].text);
        }
    }
}
