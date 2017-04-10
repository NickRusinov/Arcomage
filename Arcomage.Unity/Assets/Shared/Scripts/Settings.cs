using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Settings
    {
        public Settings()
        {
            IsSingle = true;
            IsNetwork = false;

            Single = new SingleSettings();
            Network = new NetworkSettings();
        }

        public bool IsSingle { get; private set; }

        public bool IsNetwork { get; private set; }

        public SingleSettings Single { get; private set; }

        public NetworkSettings Network { get; private set; }

        public void UseSingle()
        {
            IsSingle = true;
            IsNetwork = false;
        }

        public void UseNetwork()
        {
            IsSingle = false;
            IsNetwork = true;
        }
    }
}
