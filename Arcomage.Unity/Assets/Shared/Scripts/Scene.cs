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
        public static Authorization Authorization;

        public static IContainer Container;

        public static Logger Logger;

        protected ILifetimeScope lifetimeScope;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            Debug.Log("Инициализация игры");

#if   UNITY_EDITOR

            Container = new AutofacConfiguration().Configure();
            Authorization = new UnityAuthorization();
            Logger = new UnityLogger();

#elif UNITY_ANDROID
            
            Container = new AutofacConfiguration().Configure();
            Authorization = new AndroidAuthorization();
            Logger = new AndroidLogger();

#endif

            Application.logMessageReceived += Logger.Log;

        }

        public virtual void Awake()
        {
#if   !UNITY_EDITOR

            LanguageManager.Instance.defaultLanguage = Application.systemLanguage.GetLanguageCode();
            LanguageManager.Instance.ChangeLanguage(LanguageManager.Instance.defaultLanguage);

#endif
            lifetimeScope = Container.BeginLifetimeScope(b => b.RegisterInstance(this));
        }

        public virtual void OnDestroy()
        {
            lifetimeScope.Dispose();
        }
    }
}
