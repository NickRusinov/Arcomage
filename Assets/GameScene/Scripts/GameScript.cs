using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Rules;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class GameScript : ObservableScript
    {
        public void Initialize(Game game, ClassicRule rule, CardFactory cardFactory)
        {
            this.ResolveScript<ResourcesScript>("ResourcesLeft").Initialize(game.FirstPlayer.Resources);
            this.ResolveScript<ResourcesScript>("ResourcesRight").Initialize(game.SecondPlayer.Resources);

            this.ResolveScript<BuildingsScript>("BuildingsLeft").Initialize(game.FirstPlayer.Buildings, rule);
            this.ResolveScript<BuildingsScript>("BuildingsRight").Initialize(game.SecondPlayer.Buildings, rule);

            this.ResolveScript<HistoryScript>("History").Initialize(game.History, cardFactory);
            this.ResolveScript<HandScript>("Hand").Initialize(game.FirstPlayer.Hand, cardFactory);
        }
    }
}