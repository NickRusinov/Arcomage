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
        [Tooltip("Язык")]
        public string Culture;

        public void Start()
        {
            Thread.CurrentThread.CurrentUICulture = FrameworkExtensions.GetCultureInfoOrInvariant(Culture);
        }
    }
}
