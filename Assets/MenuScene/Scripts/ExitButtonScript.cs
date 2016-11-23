using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.MenuScene.Scripts
{
    public class ExitButtonScript : MonoBehaviour
    {
        public void OnClickHandler()
        {
            Application.Quit();
        }
    }
}
