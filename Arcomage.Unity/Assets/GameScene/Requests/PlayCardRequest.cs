using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;

namespace Arcomage.Unity.GameScene.Requests
{
    public class PlayCardRequest : IRequest
    {
        public PlayCardRequest(int index)
        {
            Index = index;
        }

        public int Index { get; set; }
    }
}
