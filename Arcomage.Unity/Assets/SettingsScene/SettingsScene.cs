using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Framework;
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
    public class SettingsScene : Scene
    {
        [Tooltip("Компонент настроек игры")]
        public SettingsView Settings;

        public override void Awake()
        {
            base.Awake();

            var settings = LifetimeScope.Resolve<Settings>();
            var settingsViewModel = LifetimeScope.Resolve<SettingsViewModel>();

            settings.UseSingle();
            Settings.ViewModel = settingsViewModel;
        }
    }
}
