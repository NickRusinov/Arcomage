using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartLocalization;
using UnityEngine;

namespace Arcomage.Unity.Framework
{
    public abstract class Scene : MonoBehaviour
    {
        public virtual void Awake()
        {
            Global.Instance = Global.BeginLifetimeScope(this);

            if (!Application.isEditor)
            {
                LanguageManager.Instance.defaultLanguage = LanguageManager.Instance.GetLanguageCode(Application.systemLanguage);
                LanguageManager.Instance.ChangeLanguage(LanguageManager.Instance.defaultLanguage);
            }
        }

        public virtual void OnDestroy()
        {
            Global.Instance.Dispose();
        }
    }
}
