using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Arcomage.Unity.Framework
{
    public class UnityLogTextWriter : TextWriter
    {
        public override Encoding Encoding => Encoding.Default;

        public override void Write(string value)
        {
            Debug.Log(value);
        }
    }
}
