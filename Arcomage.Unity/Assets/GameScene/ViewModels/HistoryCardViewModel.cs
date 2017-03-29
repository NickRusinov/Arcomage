using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Resources;

namespace Arcomage.Unity.GameScene.ViewModels
{
    public class HistoryCardViewModel
    {
        public int Id { get; set; }

        public int Index { get; set; }

        public string Identifier { get; set; }

        public bool IsPlayed { get; set; }

        public ResourceKind Kind { get; set; }

        public int Price { get; set; }
        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            return Id == ((HistoryCardViewModel)obj).Id;
        }
    }
}
