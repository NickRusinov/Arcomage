using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using MediatR;
using SmartLocalization;
using UnityEngine;

namespace Arcomage.Unity.Framework
{
    public abstract class Scene : MonoBehaviour
    {
        private static IContainer container;

        public static ILifetimeScope LifetimeScope { get; private set; }

        public static IMediator Mediator { get; private set; }

        public static void Initialize(IContainer container)
        {
            Scene.container = container;
            Application.logMessageReceived += (m, st, lt) => LifetimeScope.Resolve<Services.Logger>().Log(m, st, lt);
        }

        public virtual void Awake()
        {
            LifetimeScope = container.BeginLifetimeScope(b => b.RegisterInstance(this));
            Mediator = LifetimeScope.Resolve<IMediator>();

            if (!Application.isEditor)
            {
                var languageCode = LanguageManager.Instance.GetLanguageCode(Application.systemLanguage);
                LanguageManager.Instance.defaultLanguage = languageCode;
                LanguageManager.Instance.ChangeLanguage(languageCode);
            }
        }

        public virtual void OnDestroy()
        {
            LifetimeScope.Dispose();
        }
    }
}
