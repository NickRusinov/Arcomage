using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.SettingsScene.Views;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.SettingsScene.Scripts
{
    public class SettingsSceneScript : SceneScript
    {
        [Tooltip("Компонент настроек игры")]
        public SettingsView SettingsScript;

        public void Start()
        {
            SettingsScript.Initialize();
        }
    }
}
