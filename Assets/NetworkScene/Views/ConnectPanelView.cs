using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Controllers;
using Arcomage.WebApi.Client.Models.About;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.NetworkScene.Views
{
    public class ConnectPanelView : View
    {
        [Tooltip("Объект, активирующийся при удачном соединении с игровым веб-сервером")]
        public GameObject SuccessObject;

        [Tooltip("Объект, активирующийся при неудачном соединении с игровым веб-сервером")]
        public GameObject FailureObject;

        public void Initialize(AboutClient aboutClient)
        {
            var getVersionTask = aboutClient.GetVersion();

            StartCoroutine(GetVersionCoroutine(getVersionTask));
        }

        private IEnumerator GetVersionCoroutine(Task<VersionModel> task)
        {
            while (!task.IsCompleted)
                yield return null;

            if (task.Status == TaskStatus.RanToCompletion)
                SuccessObject.SetActive(true);

            if (task.Status == TaskStatus.Faulted)
            {
                FailureObject.SetActive(true);
                FailureObject.GetComponent<Text>().text = task.Exception.InnerExceptions[0].ToString();
            }
        }
    }
}
