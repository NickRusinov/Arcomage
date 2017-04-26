using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Arcomage.Network.Notifications
{
    public class StartGameNotification : INotification
    {
        public StartGameNotification(GameContext gameContext)
        {
            GameContext = gameContext;
        }

        public GameContext GameContext { get; set; }
    }
}
