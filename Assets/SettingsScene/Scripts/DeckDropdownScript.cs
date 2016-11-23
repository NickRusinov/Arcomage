using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Scripts
{
    public class DeckDropdownScript : DropdownScript
    {
        protected override void CreateItem(DropdownItem item, int index)
        {
            var itemLabelText = item.ResolveScript<Text>("ItemLabel");

            itemLabelText.text = Localization.ResourceManager.GetString("Deck" + options[index].text + "Name");
        }

        public override void OnChangedHandler(int index)
        {
            captionText.text = Localization.ResourceManager.GetString("Deck" + options[index].text + "Name");
        }
    }
}
