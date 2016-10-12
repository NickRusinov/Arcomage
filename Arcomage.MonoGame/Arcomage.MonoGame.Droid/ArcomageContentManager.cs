using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Arcomage.MonoGame.Droid
{
    public class ArcomageContentManager : ContentManager
    {
        public ArcomageContentManager(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            
        }

        public ArcomageContentManager(IServiceProvider serviceProvider, string rootDirectory)
            : base(serviceProvider, rootDirectory)
        {
            
        }

        public override T Load<T>(string assetName)
        {
            if (typeof(T) == typeof(string))
            {
                var localization = base.Load<Dictionary<string, string>>("Localization");
                string result;

                if (localization.TryGetValue(assetName, out result))
                    return (T)(object)result;

                return (T)(object)$"<{ assetName }>";
            }

            return base.Load<T>(assetName);
        }
    }
}