using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Services
{
    public interface IPlayCardCriteria
    {
        bool CanPlayCard(Game game, Player player, int cardIndex);
    }
}
