using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public static class LanguageExtensions
    {
        public static string GetLanguageCode(this SystemLanguage language)
        {
            switch (language)
            {
                case SystemLanguage.English:
                    return "en-US";

                case SystemLanguage.Russian:
                    return "ru-RU";

                default:
                    return "en-US";
            }
        }
    }
}
