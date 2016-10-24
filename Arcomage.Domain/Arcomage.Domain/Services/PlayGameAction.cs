using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;
using Arcomage.Domain.Internal;

namespace Arcomage.Domain.Services
{
    public class PlayGameAction : IGameAction
    {
        public void Execute(Game game, int cardIndex)
        {
            var player = game.GetCurrentPlayer();

            Task.Run(() => player.Play(game));
        }
    }
}
