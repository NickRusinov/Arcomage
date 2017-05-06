using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartLocalization;
using UnityEngine;

namespace Arcomage.Unity.Framework
{
    public static class SmartLocalizationExtensions
    {
        public static string TryGetTextValue(this LanguageManager manager, string key)
        {
            return manager.GetTextValue(key) ?? key;
        }

        public static string GetLanguageCode(this LanguageManager manager, SystemLanguage language)
        {
            if (language is SystemLanguage.Russian && manager.IsCultureSupported("ru-RU"))
                return "ru-RU";

            return "en-US";
        }
    }
}
