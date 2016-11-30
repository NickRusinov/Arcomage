using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class FinishedMenuScript : View
    {
        [Tooltip("Текст для вывода причины завершения игры")]
        public Text CauseText;

        public void Initialize(Game game)
        {
            Bind(game, g => g.Result.GetIdentifier())
                .OnChangedAndInit(i => CauseText.text = Localization.ResourceManager.GetString("GameFinished" + i + "Text"));
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
