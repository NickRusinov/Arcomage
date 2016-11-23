using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arcomage.Domain.Entities;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class FinishedMenuScript : ObservableScript
    {
        public void Initialize(Game game)
        {
            Initialize(
                game.Observable(g => g.Result, gr => this.UpdateLocalization("CauseText", "GameFinished" + gr.GetIdentifier() + "Text")));
        }
    }
}
