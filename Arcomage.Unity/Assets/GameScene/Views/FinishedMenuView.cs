using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.GameScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.GameScene.Views
{
    /// <summary>
    /// Представление компонента меню завершения игры
    /// </summary>
    public class FinishedMenuView : View<FinishedMenuViewModel>
    {
        [Tooltip("Текст для вывода причины завершения игры")]
        public LocalizationScript CauseText;

        [Tooltip("Текст для вывода имени игрока победителя")]
        public LocalizationScript WinnerText;

        protected override void OnViewModel(FinishedMenuViewModel viewModel)
        {
            Bind(viewModel, f => f.Identifier)
                .OnChangedAndInit(i => CauseText.identifier = "GameFinished" + i + "Text");

            Bind(viewModel, f => f.Name)
                .OnChangedAndInit(p => WinnerText.identifier = "GameFinishedWinnerText")
                .OnChangedAndInit(p => WinnerText.arguments = new[] { p });
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Назад"
        /// </summary>
        public void OnBackClickHandler()
        {
            SceneManager.LoadScene("MenuScene");
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Заново"
        /// </summary>
        public void OnPlayClickHandler()
        {
            SceneManager.LoadScene("GameScene");
        }

        /// <summary>
        /// Обработчик на появление меню на экране
        /// </summary>
        public void OnShowHandler()
        {
            GameSceneScript.Pause = true;
        }
    }
}
