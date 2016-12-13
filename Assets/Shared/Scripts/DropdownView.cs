using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Arcomage.Unity.Shared.Scripts
{
    public class DropdownView : Dropdown
    {
        private static readonly FieldInfo itemsFieldInfo = typeof(Dropdown).GetField("m_Items", BindingFlags.Instance | BindingFlags.NonPublic);

        protected DropdownView()
        {
            onValueChanged.AddListener(OnChangedHandler);
        }

        protected sealed override DropdownItem CreateItem(DropdownItem itemTemplate)
        {
            var item = base.CreateItem(itemTemplate);
            var index = ((ICollection)itemsFieldInfo.GetValue(this)).Count;

            CreateItem(item, index);

            return item;
        }

        protected virtual void CreateItem(DropdownItem item, int index)
        {
        
        }

        protected virtual void OnChangedHandler(int index)
        {

        }
    }
}
