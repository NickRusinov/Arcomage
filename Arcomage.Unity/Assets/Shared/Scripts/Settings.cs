using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcomage.Unity.Shared.Scripts
{
    public class Settings
    {
        public static readonly Settings Instance = new Settings();

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

        public void UseSingle(SingleSettings settings)
        {
            IsSingle = true;
            IsNetwork = false;
            
            Single = settings;
        }

        public void UseNetwork(NetworkSettings settings)
        {
            IsSingle = false;
            IsNetwork = true;

            Network = settings;
        }
    }
}
