using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.GameScene.Views
{
    public class FinishedMenuView : View
    {
        [Tooltip("Текст для вывода причины завершения игры")]
        public LocalizationScript CauseText;

        [Tooltip("Текст для вывода имени игрока победителя")]
        public LocalizationScript WinnerText;

        public void Initialize(Game game)
        {
            Bind(game, g => g.Rule.IsWin(g).GetIdentifier())
                .OnChangedAndInit(i => CauseText.identifier = "GameFinished" + i + "Text");

            Bind(game, g => g.Rule.IsWin(g).Player)
                .OnChangedAndInit(p => WinnerText.identifier = "GameFinishedWinnerText")
                .OnChangedAndInit(p => WinnerText.arguments = new[] { p.GetName() });
        }

        public void OnBackClickHandler()
        {
            SceneManager.LoadScene("MenuScene");
        }

        public void OnPlayClickHandler()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void OnShowHandler()
        {
            GameSceneScript.Pause = true;
        }
    }
}
