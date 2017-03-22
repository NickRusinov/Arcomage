using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Resources;

namespace Arcomage.Unity.GameScene.ViewModels
{
    public class CardViewModel
    {
        public int Index { get; set; }

        public string Identifier { get; set; }

        public ResourceKind Kind { get; set; }

        public int Price { get; set; }
        
        public override int GetHashCode()
        {
            return Index.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            return Index == ((CardViewModel)obj).Index;
        }
    }
}
