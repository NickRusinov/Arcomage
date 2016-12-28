using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SmartLocalization;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Settings
    {
        public static Settings Instance = new Settings();

        public string FirstPlayer = LanguageManager.Instance.GetTextValue("SettingsFirstPlayerDefaultName");

        public string SecondPlayer = LanguageManager.Instance.GetTextValue("SettingsSecondPlayerDefaultName");

        public string Rule = "EmpireCapital";

        public string Deck = "Classic";
    }
}
