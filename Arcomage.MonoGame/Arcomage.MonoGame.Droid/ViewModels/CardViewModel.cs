using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    public class CardViewModel : ViewModel
    {
        public string Identifier { get; set; }

        public string Resource { get; set; }

        public int Price { get; set; }
    }
}
