using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    public class CardViewModel : ViewModel
    {
        public string Identifier { get; set; }

        public int ResourcePrice { get; set; }

        public string ResourceMode { get; set; }
    }
}
