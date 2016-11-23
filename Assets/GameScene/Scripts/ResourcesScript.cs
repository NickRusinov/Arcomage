using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Unity.Shared.Scripts;
using Resources = Arcomage.Domain.Entities.Resources;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class ResourcesScript : ObservableScript
    {
        public void Initialize(Resources resources)
        {
            Initialize(
                resources.Observable(r => r.Quarry, q => this.UpdateText("QuarryText", "+" + q)),
                resources.Observable(r => r.Bricks, b => this.UpdateText("BricksText", b)),
                resources.Observable(r => r.Magic, m => this.UpdateText("MagicText", "+" + m)),
                resources.Observable(r => r.Gems, g => this.UpdateText("GemsText", g)),
                resources.Observable(r => r.Dungeons, d => this.UpdateText("DungeonsText", "+" + d)),
                resources.Observable(r => r.Recruits, r => this.UpdateText("RecruitsText", r)));
        }
    }
}
