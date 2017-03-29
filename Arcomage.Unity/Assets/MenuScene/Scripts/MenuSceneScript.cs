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
    public class MenuSceneScript : Shared.Scripts.Scene
    {
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnExitClickHandler();
        }

        /// <summary>
        /// Click handler for single play button of menu
        /// </summary>
        public void OnSinglePlayClickHanlder()
        {
            SceneManager.LoadScene("SettingsScene");
        }

        /// <summary>
        /// Click handler for network play button of menu
        /// </summary>
        public void OnNetworkPlayClickHandler()
        {
            SceneManager.LoadScene("NetworkScene");
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
