using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Unity.NetworkScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arcomage.Unity.NetworkScene.Views
{
    public class ConnectPanelView : View<ConnectViewModel>
    {
        [Tooltip("Объект, активирующийся при удачном соединении с игровым веб-сервером")]
        public GameObject SuccessObject;

        [Tooltip("Объект, активирующийся при неудачном соединении с игровым веб-сервером")]
        public GameObject FailureConnectObject;

        [Tooltip("Объект, активирующийся при несоответствующей версии клиента и игрового веб-сервера")]
        public GameObject FailureVersionObject;

        public void OnEnable()
        {
            Bind(ViewModel.GetVersionCommand.Execute(ViewModel))
                .OnComplete(t => gameObject.SetActive(false))
                .OnSuccess(t => SuccessObject.SetActive(t.Result.Version == 0))
                .OnSuccess(t => FailureVersionObject.SetActive(t.Result.Version != 0))
                .OnFailure(t => FailureConnectObject.SetActive(true));
        }

        public void OnBackButtonClickHandler()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
