using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Arcomage.Unity.NetworkScene.Requests;
using Arcomage.Unity.Shared.Scripts;
using Arcomage.WebApi.Client.Models.About;
using UnityEngine;

namespace Arcomage.Unity.NetworkScene.Views
{
    public class ConnectPanelView : View
    {
        [Tooltip("Объект, активирующийся при удачном соединении с игровым веб-сервером и отсутствующей активной игры")]
        public GameObject SuccessNotExistsGameObject;

        [Tooltip("Объект, активирующийся при удачном соединении  игровым веб-сервером и наличии активной игры")]
        public GameObject SuccessExistsGameObject;

        [Tooltip("Объект, активирующийся при неудачном соединении с игровым веб-сервером")]
        public GameObject FailureConnectObject;

        [Tooltip("Объект, активирующийся при несоответствующей версии клиента и игрового веб-сервера")]
        public GameObject FailureVersionObject;

        public void OnEnable()
        {
            Bind(Scene.Mediator.Send(new GetVersionRequest(), CancellationToken.None))
                .OnSuccess(t => OnGetVersionCorrectSuccess(t.Result), t => t.Result.Version == 0)
                .OnSuccess(t => OnGetVersionIncorrectSuccess(t.Result), t => t.Result.Version != 0)
                .OnFailure(t => OnGetVersionFailure());
        }

        private void OnGetVersionCorrectSuccess(VersionModel versionModel)
        {
            Bind(Scene.Mediator.Send(new GetConnectingGameRequest(), CancellationToken.None))
                .OnSuccess(t => OnGetConnectingGameExistsSuccess(), t => t.Result.HasValue)
                .OnSuccess(t => OnGetConnectingGameNotExistsSuccess(), t => !t.Result.HasValue)
                .OnFailure(t => OnGetConnectingGameFailure());
        }

        private void OnGetVersionIncorrectSuccess(VersionModel versionModel)
        {
            gameObject.SetActive(false);
            FailureVersionObject.SetActive(true);
        }

        private void OnGetVersionFailure()
        {
            gameObject.SetActive(false);
            FailureConnectObject.SetActive(true);
        }

        private void OnGetConnectingGameExistsSuccess()
        {
            gameObject.SetActive(false);
            SuccessExistsGameObject.SetActive(true);
        }

        private void OnGetConnectingGameNotExistsSuccess()
        {
            gameObject.SetActive(false);
            SuccessNotExistsGameObject.SetActive(true);
        }

        private void OnGetConnectingGameFailure()
        {
            gameObject.SetActive(false);
            FailureConnectObject.SetActive(true);
        }
    }
}
