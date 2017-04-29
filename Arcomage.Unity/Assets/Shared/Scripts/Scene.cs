using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using MediatR;
using SmartLocalization;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Scene : MonoBehaviour
    {
        private static IContainer Container;

        public static Authorization Authorization;

        public static Logger Logger;

        public static IMediator Mediator;

        protected ILifetimeScope lifetimeScope;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            Debug.Log("Инициализация игры");

            Container = new AutofacConfiguration().Configure();
            Application.logMessageReceived += (message, stackTrace, logType) => Logger.Log(message, stackTrace, logType);
        }

        public virtual void Awake()
        {
#if !UNITY_EDITOR

            LanguageManager.Instance.defaultLanguage = Application.systemLanguage.GetLanguageCode();
            LanguageManager.Instance.ChangeLanguage(LanguageManager.Instance.defaultLanguage);

#endif
            lifetimeScope = Container.BeginLifetimeScope(b => b.RegisterInstance(this));

            Authorization = lifetimeScope.Resolve<Authorization>();
            Logger = lifetimeScope.Resolve<Logger>();
            Mediator = lifetimeScope.Resolve<IMediator>();
        }

        public virtual void OnDestroy()
        {
            lifetimeScope.Dispose();
        }
    }
}
