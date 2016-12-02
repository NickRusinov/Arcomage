using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Settings
    {
        public static Settings Instance = new Settings();

        public string FirstPlayer = Localization.ResourceManager.GetString("SettingsFirstPlayerDefaultName");

        public string SecondPlayer = Localization.ResourceManager.GetString("SettingsSecondPlayerDefaultName");

        public string Rule = "EmpireCapital";

        public string Deck = "Classic";
    }
}
