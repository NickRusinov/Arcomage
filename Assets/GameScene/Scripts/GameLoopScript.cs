using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcomage.Domain;
using Arcomage.Unity.Shared.Scripts;

namespace Arcomage.Unity.GameScene.Scripts
{
    public class GameLoopScript : Script
    {
        private GameLoop gameLoop;

        public void Initialize(GameLoop gameLoop)
        {
            this.gameLoop = gameLoop;
        }
    
        public override void Update()
        {
            gameLoop.Update();
        }
    }
}