using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public abstract class GameCondition : IIdentifiable
    {
        public string Identifier { get; set; }

        public abstract Buildings CreateBuildings();

        public abstract Resources CreateResources();

        public abstract WinResult IsWin(Game game);
    }
}
