using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.GameScene.ViewModels
{
    public class HistoryViewModel
    {
        public HistoryViewModel()
        {
            Cards = new List<HistoryCardViewModel>();
        }

        public IList<HistoryCardViewModel> Cards { get; set; }
    }
}
