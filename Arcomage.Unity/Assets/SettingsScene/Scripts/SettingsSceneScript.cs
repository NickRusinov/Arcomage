using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.SettingsScene.Views;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.SettingsScene.Scripts
{
    /// <summary>
    /// Root script for settings scene
    /// </summary>
    public class SettingsSceneScript : Shared.Scripts.Scene
    {
        [Tooltip("Компонент настроек игры")]
        public SettingsView Settings;

        public override void Awake()
        {
            base.Awake();

            Shared.Scripts.Settings.Instance.UseSingle(new SingleSettings());
        }

        public void Start()
        {
            Settings.Initialize();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnBackClickHandler();
        }

        /// <summary>
        /// Click handler for play button of menu
        /// </summary>
        public void OnPlayClickHandler()
        {
            SceneManager.LoadScene("GameScene");
        }

        /// <summary>
        /// Click handler for back button of menu
        /// </summary>
        public void OnBackClickHandler()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
