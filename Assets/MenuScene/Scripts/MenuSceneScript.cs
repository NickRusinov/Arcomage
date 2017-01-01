using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.MenuScene.Scripts
{
    /// <summary>
    /// Root script for menu scene
    /// </summary>
    public class MenuSceneScript : SceneScript
    {
        /// <summary>
        /// Click handler for play button of menu
        /// </summary>
        public void OnPlayClickHanlder()
        {
            SceneManager.LoadScene("SettingsScene");
        }

        /// <summary>
        /// Click handler for exit button of menu
        /// </summary>
        public void OnExitClickHandler()
        {
            Application.Quit();
        }
    }
}
