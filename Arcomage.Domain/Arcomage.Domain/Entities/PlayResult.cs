using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcomage.Domain.Entities
{
    public struct PlayResult
    {
        public static readonly PlayResult None = new PlayResult();

        public PlayResult(int card, bool isPlay)
            : this()
        {
            Card = card;
            IsPlay = isPlay;
            IsDiscard = !isPlay;
        }

        public int Card { get; }

        public bool IsPlay { get; }

        public bool IsDiscard { get; }
    }
}
