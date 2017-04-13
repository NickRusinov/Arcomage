using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.GameScene.ViewModels
{
    public class HandViewModel
    {
        public HandViewModel()
        {
            Cards = new List<CardViewModel>();
        }

        public IList<CardViewModel> Cards { get; set; }
    }
}
