using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.SettingsScene.ViewModels;
using Arcomage.Unity.SettingsScene.Views;
using Arcomage.Unity.Shared.Scripts;
using Autofac;
using UnityEngine;

namespace Arcomage.Unity.SettingsScene
{
    /// <summary>
    /// Root script for settings scene
    /// </summary>
    [RequireComponent(typeof(UnityBackHandler))]
    [RequireComponent(typeof(UnitySceneManager))]
    public class SettingsScene : Scene
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
    }
}
