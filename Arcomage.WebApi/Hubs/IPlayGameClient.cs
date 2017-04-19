using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.WebApi.Models.Game;

namespace Arcomage.WebApi.Hubs
{
    public interface IPlayGameClient
    {
        void Update(GameModel gameModel);
    }
}
