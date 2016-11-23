using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModestTree;

namespace Arcomage.Unity.Shared.Scripts
{
    public partial class CultureScript
    {
        public void OnValidate()
        {
            Start();

            FindObjectsOfType<LocalizationScript>()
                .ForEach(ls => ls.OnValidate());
        }
    }
}
