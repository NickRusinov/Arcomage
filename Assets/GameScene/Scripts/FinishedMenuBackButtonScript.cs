using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class FinishedMenuBackButtonScript : MonoBehaviour
    {
        public void OnClickHandler()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
