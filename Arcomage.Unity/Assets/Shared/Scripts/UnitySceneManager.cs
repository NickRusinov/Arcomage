using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.Shared.Scripts
{
    public class UnitySceneManager : MonoBehaviour
    {
        public void LoadMenuScene()
        {
            SceneManager.LoadScene("MenuScene");
        }

        public void LoadSettingsScene()
        {
            SceneManager.LoadScene("SettingsScene");
        }

        public void LoadNetworkScene()
        {
            SceneManager.LoadScene("NetworkScene");
        }

        public void LoadGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
