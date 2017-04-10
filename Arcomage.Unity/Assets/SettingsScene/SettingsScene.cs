using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.SettingsScene.ViewModels;
using Arcomage.Unity.SettingsScene.Views;
using Arcomage.Unity.Shared.Scripts;
using Autofac;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.SettingsScene
{
    /// <summary>
    /// Root script for settings scene
    /// </summary>
    public class SettingsScene : Shared.Scripts.Scene
    {
        [Tooltip("Компонент настроек игры")]
        public SettingsView Settings;

        public void Start()
        {
            var settings = lifetimeScope.Resolve<Settings>();
            var settingsViewModel = lifetimeScope.Resolve<SettingsViewModel>();

            settings.UseSingle();
            Settings.ViewModel = settingsViewModel;
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
