using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PropertyChanged;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    [ImplementPropertyChanged]
    public class MenuViewModel : PageViewModel
    {
        public ButtonViewModel PlayButton { get; set; }

        public ButtonViewModel SettingsButton { get; set; }

        public ButtonViewModel ExitButton { get; set; }
    }
}