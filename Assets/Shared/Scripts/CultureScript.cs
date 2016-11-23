using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Arcomage.Unity.Shared.Scripts
{
    public partial class CultureScript : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Язык")]
        public string culture;

        public void Start()
        {
            Thread.CurrentThread.CurrentUICulture = FrameworkExtensions.GetCultureInfoOrInvariant(culture);
        }
    }
}
