using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Arcomage.Unity.Shared.Scripts
{
    [RequireComponent(typeof(Text))]
    public partial class LocalizationScript : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Идентификатор строки для локализации")]
        private string identifier;

        private Text text;

        public string Identifier
        {
            get { return identifier; }
            set { FrameworkExtensions.Setter(out identifier, value, Start); }
        }

        public void Awake()
        {
            text = GetComponent<Text>();
        }

        public void Start()
        {
            text.text = Localization.ResourceManager.GetString(identifier);
        }
    }
}
