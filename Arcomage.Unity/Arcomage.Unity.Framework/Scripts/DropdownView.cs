using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Arcomage.Unity.Framework.Scripts
{
    public class DropdownView : Dropdown
    {
        private static readonly FieldInfo itemsFieldInfo = typeof(Dropdown).GetField("m_Items", BindingFlags.Instance | BindingFlags.NonPublic);

        [Tooltip("Событие, вызываемое при открытии списка")]
        public UnityEvent OnDropdownOpened;

        [Tooltip("Событие, вызываемое при закрытии списка")]
        public UnityEvent OnDropdownClosed;

        protected DropdownView()
        {
            onValueChanged.AddListener(OnChangedHandler);
        }

        protected override GameObject CreateDropdownList(GameObject template)
        {
            var list = base.CreateDropdownList(template);
            OnDropdownOpened.Invoke();

            return list;
        }

        protected override void DestroyDropdownList(GameObject dropdownList)
        {
            base.DestroyDropdownList(dropdownList);
            OnDropdownClosed.Invoke();
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
