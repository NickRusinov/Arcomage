using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain;
using MediatR;

namespace Arcomage.Network.Notifications
{
    public class AfterPlayCardGameNotification : INotification
    {
        public AfterPlayCardGameNotification(GameContext gameContext, Game game)
        {
            GameContext = gameContext;
            Game = game;
        }

        public GameContext GameContext { get; set; }

        public Game Game { get; set; }
    }
}
