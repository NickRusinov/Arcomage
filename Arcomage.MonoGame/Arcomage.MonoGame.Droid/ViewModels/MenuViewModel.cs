using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        public ButtonViewModel PlayButton { get; set; }

        public ButtonViewModel SettingsButton { get; set; }

        public ButtonViewModel ExitButton { get; set; }
    }
}