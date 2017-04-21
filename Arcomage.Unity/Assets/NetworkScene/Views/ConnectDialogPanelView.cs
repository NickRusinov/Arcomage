using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.NetworkScene.ViewModels;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.NetworkScene.Views
{
    public class ConnectDialogPanelView : View<ConnectDialogViewModel>
    {
        [Tooltip("Объект, активирующийся при подготовке к соединении к игре")]
        public GameObject PrepareGameObject;

        [Tooltip("Объект, активирующийся при неудачном соединении с игровым веб-сервером")]
        public GameObject FailureConnectObject;

        public void OnConnectClick()
        {
            gameObject.SetActive(false);
            PrepareGameObject.SetActive(true);
        }

        public void OnDisconnectClick()
        {
            Bind(ViewModel.DisconnectGameCommand.Execute(ViewModel))
                .OnSuccess(t => OnDisconnectSuccess())
                .OnFailure(t => OnDisconnectFailure());
        }

        private void OnDisconnectSuccess()
        {
            gameObject.SetActive(false);
            PrepareGameObject.SetActive(true);
        }

        private void OnDisconnectFailure()
        {
            gameObject.SetActive(false);
            FailureConnectObject.SetActive(true);
        }
    }
}
