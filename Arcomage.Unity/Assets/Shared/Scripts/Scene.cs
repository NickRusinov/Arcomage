using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using SmartLocalization;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Scene : MonoBehaviour
    {
        protected ILifetimeScope lifetimeScope;

        public virtual void Awake()
        {
            lifetimeScope = GameApplication.Instance.Container.BeginLifetimeScope(b => b.RegisterInstance(this));

#if !UNITY_EDITOR
            Application.logMessageReceived += this.LogMessage;

            LanguageManager.Instance.defaultLanguage = Application.systemLanguage.GetLanguageCode();
            LanguageManager.Instance.ChangeLanguage(LanguageManager.Instance.defaultLanguage);
#endif
        }

        public virtual void OnDestroy()
        {
            lifetimeScope.Dispose();
        }
    }
}
