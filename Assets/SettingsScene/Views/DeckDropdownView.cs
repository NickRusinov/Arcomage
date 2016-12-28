using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Unity.Shared.Scripts;
using SmartLocalization;
using UnityEngine.UI;

namespace Arcomage.Unity.SettingsScene.Views
{
    public class DeckDropdownView : DropdownView
    {
        protected override void CreateItem(DropdownItem item, int index)
        {
            var itemLabelText = item.transform.Find("ItemLabel").GetComponent<Text>();

            itemLabelText.text = LanguageManager.Instance.GetTextValue("Deck" + options[index].text + "Name");
        }

        protected override void OnChangedHandler(int index)
        {
            captionText.text = LanguageManager.Instance.GetTextValue("Deck" + options[index].text + "Name");
        }
    }
}
