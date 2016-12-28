using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartLocalization;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.Shared.Scripts
{
    [ExecuteInEditMode]
    [RequireComponent(typeof(Text))]
    public partial class LocalizationScript : View
    {
        [Tooltip("Идентификатор строки для локализации")]
        public string identifier;
        
        public void Awake()
        {
            var text = GetComponent<Text>();
            
            Bind(this, t => t.identifier)
                .OnChangedAndInit(i => text.text = LanguageManager.Instance.GetTextValue(i));

            LanguageManager.Instance.OnChangeLanguage +=
                _ => text.text = LanguageManager.Instance.GetTextValue(identifier);
        }

#if UNITY_EDITOR
        private string oldLanguageCode;

        private string oldIdentifier;

        public override void Update()
        {
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
