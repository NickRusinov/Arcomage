using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.SettingsScene.Scripts
{
    public class SettingsSceneScript : MonoBehaviour
    {
        [Tooltip("Компонент настроек игры")]
        public SettingsScript SettingsScript;

        public void Start()
        {
            SettingsScript.Initialize();
        }
    }
}
