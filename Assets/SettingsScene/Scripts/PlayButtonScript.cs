using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.SettingsScene.Scripts
{
    public class PlayButtonScript : MonoBehaviour
    {
        public void OnClickHandler()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
