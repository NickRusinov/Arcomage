using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Resources;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.ViewModels
{
    public class CardViewModel
    {
        public int Id { get; set; }

        public int Index { get; set; }

        public string Identifier { get; set; }

        public bool IsPlay { get; set; }

        public bool IsDiscard { get; set; }

        public ResourceKind Kind { get; set; }

        public int Price { get; set; }

        public Command<CardViewModel> PlayCommand { get; set; }

        public Command<CardViewModel> DiscardCommand { get; set; }
        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        
        public override bool Equals(object obj)
        {
            return Id == ((CardViewModel)obj).Id;
        }
    }
}
