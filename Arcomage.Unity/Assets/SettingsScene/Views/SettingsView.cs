using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Unity.Framework;
using Arcomage.Unity.Framework.Bindings;
using Arcomage.Unity.SettingsScene.Requests;
using Arcomage.Unity.SettingsScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class SettingsView : View<SettingsViewModel>
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

        [Tooltip("Кнопка запуска игры")]
        public Button PlayButton;

        [Tooltip("Аниматор, анимирующий появление и скрытие списков выбора")]
        public Animator Animator;

        [Tooltip("Менеджер сцен")]
        public UnitySceneManager SceneManager;

        protected override void OnViewModel(SettingsViewModel viewModel)
        {
            DeckListView.ViewModel = viewModel.DeckList;
            RuleListView.ViewModel = viewModel.RuleList;

            Bind(viewModel.Settings, s => s.FirstPlayer)
                .OnChangedAndInit(s => FirstPlayerInput.text = s);

            Bind(viewModel.Settings, s => s.SecondPlayer)
                .OnChangedAndInit(s => SecondPlayerInput.text = s);

            Bind(viewModel.Settings, s => s.Deck)
                .OnChangedAndInit(d => DeckText.identifier = "Deck" + d.Identifier + "Name");

            Bind(viewModel.Settings, s => s.Rule)
                .OnChangedAndInit(r => RuleText.identifier = "Rule" + r.Identifier + "Name");

            Bind(() => Input.GetKeyDown(KeyCode.Escape))
                .OnChangedAndInit(x => x && viewModel.DeckList.IsShow, x => Animator.Play("HideDeckAnimation"))
                .OnChangedAndInit(x => x && viewModel.RuleList.IsShow, x => Animator.Play("HideRuleAnimation"))
                .OnChangedAndInit(x => x && !viewModel.DeckList.IsShow && !viewModel.RuleList.IsShow, x => SceneManager.LoadMenuScene());

            FirstPlayerInput.onEndEdit
                .AddListener(s => viewModel.Settings.FirstPlayer = s);

            SecondPlayerInput.onEndEdit
                .AddListener(s => viewModel.Settings.SecondPlayer = s);

            PlayButton.onClick
                .AddListener(() => Bind(Global.Mediator.Send(new PlayRequest(), CancellationToken.None))
                    .OnSuccess(_ => SceneManager.LoadGameScene()));
        }
    }
}
