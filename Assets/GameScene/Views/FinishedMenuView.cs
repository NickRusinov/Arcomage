using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.GameScene.Scripts;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Arcomage.Unity.GameScene.Views
{
    public class FinishedMenuView : View
    {
        [Tooltip("Текст для вывода причины завершения игры")]
        public Text CauseText;

        [Tooltip("Текст для вывода имени игрока победителя")]
        public Text WinnerText;

        public void Initialize(Game game)
        {
            Bind(game, g => g.Result.GetIdentifier())
                .OnChangedAndInit(i => CauseText.text = Localization.ResourceManager.GetString("GameFinished" + i + "Text"));

            Bind(game, g => g.Result.Player.Identifier)
                .OnChangedAndInit(i => WinnerText.text = string.Format(Localization.GameFinishedWinnerText, i));
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
