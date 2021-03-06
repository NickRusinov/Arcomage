﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using UnityEngine.Events;
using UnityEngine;
using Arcomage.Unity.NetworkScene.Requests;
using Arcomage.Unity.Framework;

namespace Arcomage.Unity.NetworkScene.Views
{
    public class PreparePanelView : View
    {
        [Tooltip("Событие, вызываемое при установлении соединения с игрой")]
        public UnityEvent ConnectedEvent;

        [Tooltip("Объект, активирующийся при неудачном соединении с игровым веб-сервером")]
        public GameObject FailureConnectObject;

        public void OnEnable()
        {
            Bind(Scene.Mediator.Send(new ConnectGameRequest(), CancellationToken.None))
                .OnSuccess(t => Bind(Scene.Mediator.Send(new PlayRequest(), CancellationToken.None))
                    .OnSuccess(tt => ConnectedEvent.Invoke())
                    .OnFailure(tt => OnConnectGameFailure()))
                .OnFailure(t => OnConnectGameFailure());
        }

        private void OnConnectGameFailure()
        {
            gameObject.SetActive(false);
            FailureConnectObject.SetActive(true);
        }
    }
}
