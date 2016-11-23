using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Rules;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class BuildingsScript : ObservableScript
    {
        public void Initialize(Buildings buildings, ClassicRule rule)
        {
            Initialize(
                buildings.Observable(b => b.Tower, t => this.UpdateText("TowerText", t)),
                buildings.Observable(b => b.Wall, w => this.UpdateText("WallText", w)),
                buildings.Observable(b => b.Tower, t => this.UpdateY("TowerImage", -330f + 180f * t / rule.MaxTower)),
                buildings.Observable(b => b.Wall, w => this.UpdateY("WallImage", -430f + 280f * w / rule.MaxTower)));
        }
    }
}
