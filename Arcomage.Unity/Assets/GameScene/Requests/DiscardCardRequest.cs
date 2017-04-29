using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;

namespace Arcomage.Unity.GameScene.Requests
{
    public class DiscardCardRequest : IRequest
    {
        public DiscardCardRequest(int index)
        {
            Index = index;
        }

        public int Index { get; set; }
    }
}
