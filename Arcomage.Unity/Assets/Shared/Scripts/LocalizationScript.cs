using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Framework;
using Arcomage.Unity.Framework.Bindings;
using SmartLocalization;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.Shared.Scripts
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Text))]
    public class LocalizationScript : View
    {
        [Tooltip("Идентификатор строки для локализации")]
        public string identifier;

        [Tooltip("Дополнительные параметры для локализации")]
        public string[] arguments;
        
        public void Awake()
        {
            var text = GetComponent<Text>();
            
            Bind(this, t => t.identifier)
                .OnChangedAndInit(i => text.text = LanguageManager.Instance.TryGetTextValue(i).TryFormat(arguments));

            Bind(this, t => t.arguments)
                .OnChangedAndInit(a => text.text = LanguageManager.Instance.TryGetTextValue(identifier).TryFormat(a));

            LanguageManager.Instance.OnChangeLanguage +=
                _ => text.text = LanguageManager.Instance.TryGetTextValue(identifier).TryFormat(arguments);
        }

#if UNITY_EDITOR
        private string oldLanguageCode;

        private string oldIdentifier;

        public override void Start()
        {
            if (Application.isPlaying)
            {
                base.Start();
                return;
            }
        }

        public override void Update()
        {
            if (Application.isPlaying)
            {
                base.Update();
                return;
            }

            if (oldLanguageCode == LanguageManager.Instance.defaultLanguage && oldIdentifier == identifier)
                return;

            oldLanguageCode = LanguageManager.Instance.defaultLanguage;
            oldIdentifier = identifier;

            if (LanguageManager.Instance.IsCultureSupported(LanguageManager.Instance.defaultLanguage))
                LanguageManager.Instance.ChangeLanguage(LanguageManager.Instance.defaultLanguage);

            GetComponent<Text>().text = LanguageManager.Instance.GetTextValue(identifier);
        }
#endif
    }
}
