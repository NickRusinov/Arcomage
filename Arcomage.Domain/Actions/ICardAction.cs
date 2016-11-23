using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcomage.Domain.Entities;

namespace Arcomage.Domain.Actions
{
    public interface ICardAction
    {
        void PlayExecute(Game game, Player player, int cardIndex);

        void DiscardExecute(Game game, Player player, int cardIndex);
    }
}
