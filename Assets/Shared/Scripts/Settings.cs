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

        public RuleInfo Rule = new RuleInfo("EmpireCapital", 2, 5, 2, 5, 2, 5, 5, 20, 50, 150);

        public DeckInfo Deck = new DeckInfo("Classic");
    }
}
