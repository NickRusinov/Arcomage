using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class CardScript : ObservableScript
    {
        public void Initialize(Card card)
        {
            card.Identifier = card.GetIdentifier();
        
            this.UpdateSprite("BackgroundImage", UnityEngine.Resources.Load<Sprite>("Card" + card.GetResources() + "Image"));
            this.UpdateSprite("ForegroundImage", UnityEngine.Resources.Load<Sprite>("Card" + card.Identifier + "Image"));

            this.UpdateText("NameText", Localization.ResourceManager.GetString("Card" + card.Identifier + "Name"));
            this.UpdateText("DescriptionText", Localization.ResourceManager.GetString("Card" + card.Identifier + "Description"));

            this.UpdateText("PriceText", card.ResourcePrice);
        }
    }
}