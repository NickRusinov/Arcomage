using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity
{
    public class AppSettings
    {
        public static readonly string Url;

        static AppSettings()
        {
#if DEBUG
            Url = "http://192.168.137.1:55994";
#else
            Url = "http://arcomagic.ru";
#endif
        }
    }
}
