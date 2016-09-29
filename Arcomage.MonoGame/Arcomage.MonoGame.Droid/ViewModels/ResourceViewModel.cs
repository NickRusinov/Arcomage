using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.MonoGame.Droid.ViewModels
{
    public class ResourceViewModel : ViewModel
    {
        public string Identifier { get; set; }

        public int Delta { get; set; }

        public int Value { get; set; }
    }
}
